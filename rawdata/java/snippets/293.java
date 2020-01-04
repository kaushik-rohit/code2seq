private Object bootstrapSinksFromDisk()
  {
    Preconditions.checkState(sinks.isEmpty(), "Already bootstrapped?!");

    final File baseDir = tuningConfig.getBasePersistDirectory();
    if (!baseDir.exists()) {
      return null;
    }

    final File[] files = baseDir.listFiles();
    if (files == null) {
      return null;
    }


    final Committed committed;
    File commitFile = null;
    try {
      commitLock.lock();
      commitFile = computeCommitFile();
      if (commitFile.exists()) {
        committed = objectMapper.readValue(commitFile, Committed.class);
      } else {
        committed = Committed.nil();
      }
    }
    catch (Exception e) {
      throw new ISE(e, "Failed to read commitFile: %s", commitFile);
    }
    finally {
      commitLock.unlock();
    }

    int rowsSoFar = 0;

    log.info("Loading sinks from[%s]: %s", baseDir, committed.getHydrants().keySet());

    for (File sinkDir : files) {
      final File identifierFile = new File(sinkDir, IDENTIFIER_FILE_NAME);
      if (!identifierFile.isFile()) {
        // No identifier in this sinkDir; it must not actually be a sink directory. Skip it.
        continue;
      }

      try {
        final SegmentIdWithShardSpec identifier = objectMapper.readValue(
            new File(sinkDir, "identifier.json"),
            SegmentIdWithShardSpec.class
        );

        final int committedHydrants = committed.getCommittedHydrants(identifier.toString());

        if (committedHydrants <= 0) {
          log.info("Removing uncommitted sink at [%s]", sinkDir);
          FileUtils.deleteDirectory(sinkDir);
          continue;
        }

        // To avoid reading and listing of "merged" dir and other special files
        final File[] sinkFiles = sinkDir.listFiles(
            (dir, fileName) -> !(Ints.tryParse(fileName) == null)
        );

        Arrays.sort(
            sinkFiles,
            (o1, o2) -> Ints.compare(Integer.parseInt(o1.getName()), Integer.parseInt(o2.getName()))
        );

        List<FireHydrant> hydrants = new ArrayList<>();
        for (File hydrantDir : sinkFiles) {
          final int hydrantNumber = Integer.parseInt(hydrantDir.getName());

          if (hydrantNumber >= committedHydrants) {
            log.info("Removing uncommitted segment at [%s]", hydrantDir);
            FileUtils.deleteDirectory(hydrantDir);
          } else {
            log.info("Loading previously persisted segment at [%s]", hydrantDir);
            if (hydrantNumber != hydrants.size()) {
              throw new ISE("Missing hydrant [%,d] in sinkDir [%s].", hydrants.size(), sinkDir);
            }

            hydrants.add(
                new FireHydrant(
                    new QueryableIndexSegment(indexIO.loadIndex(hydrantDir), identifier.asSegmentId()),
                    hydrantNumber
                )
            );
          }
        }

        // Make sure we loaded enough hydrants.
        if (committedHydrants != hydrants.size()) {
          throw new ISE("Missing hydrant [%,d] in sinkDir [%s].", hydrants.size(), sinkDir);
        }

        Sink currSink = new Sink(
            identifier.getInterval(),
            schema,
            identifier.getShardSpec(),
            identifier.getVersion(),
            tuningConfig.getMaxRowsInMemory(),
            maxBytesTuningConfig,
            tuningConfig.isReportParseExceptions(),
            null,
            hydrants
        );
        rowsSoFar += currSink.getNumRows();
        sinks.put(identifier, currSink);
        sinkTimeline.add(
            currSink.getInterval(),
            currSink.getVersion(),
            identifier.getShardSpec().createChunk(currSink)
        );

        segmentAnnouncer.announceSegment(currSink.getSegment());
      }
      catch (IOException e) {
        log.makeAlert(e, "Problem loading sink[%s] from disk.", schema.getDataSource())
           .addData("sinkDir", sinkDir)
           .emit();
      }
    }

    // Make sure we loaded all committed sinks.
    final Set<String> loadedSinks = Sets.newHashSet(
        Iterables.transform(sinks.keySet(), SegmentIdWithShardSpec::toString)
    );
    final Set<String> missingSinks = Sets.difference(committed.getHydrants().keySet(), loadedSinks);
    if (!missingSinks.isEmpty()) {
      throw new ISE("Missing committed sinks [%s]", Joiner.on(", ").join(missingSinks));
    }

    totalRows.set(rowsSoFar);
    return committed.getMetadata();
  }