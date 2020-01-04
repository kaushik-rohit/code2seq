public LimitedOutputStream createFile() throws IOException
  {
    if (bytesUsed.get() >= maxBytesUsed) {
      throw new TemporaryStorageFullException(maxBytesUsed);
    }

    synchronized (files) {
      if (closed) {
        throw new ISE("Closed");
      }

      FileUtils.forceMkdir(storageDirectory);
      if (!createdStorageDirectory) {
        createdStorageDirectory = true;
      }

      final File theFile = new File(storageDirectory, StringUtils.format("%08d.tmp", files.size()));
      final EnumSet<StandardOpenOption> openOptions = EnumSet.of(
          StandardOpenOption.CREATE_NEW,
          StandardOpenOption.WRITE
      );

      final FileChannel channel = FileChannel.open(theFile.toPath(), openOptions);
      files.add(theFile);
      return new LimitedOutputStream(theFile, Channels.newOutputStream(channel));
    }
  }