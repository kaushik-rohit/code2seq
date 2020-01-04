public void fitSequences(JavaRDD<Sequence<T>> corpus) {
        /**
         * Basically all we want for base implementation here is 3 things:
         * a) build vocabulary
         * b) build huffman tree
         * c) do training
         *
         * in this case all classes extending SeqVec, like deepwalk or word2vec will be just building their RDD<Sequence<T>>,
         * and calling this method for training, instead implementing own routines
         */

        validateConfiguration();

        if (ela == null) {
            try {
                ela = (SparkElementsLearningAlgorithm) Class.forName(configuration.getElementsLearningAlgorithm())
                                .newInstance();
            } catch (Exception e) {
                throw new RuntimeException(e);
            }
        }


        if (workers > 1) {
            log.info("Repartitioning corpus to {} parts...", workers);
            corpus.repartition(workers);
        }

        if (storageLevel != null)
            corpus.persist(storageLevel);

        final JavaSparkContext sc = new JavaSparkContext(corpus.context());

        // this will have any effect only if wasn't called before, in extension classes
        broadcastEnvironment(sc);

        Counter<Long> finalCounter;
        long numberOfSequences = 0;

        /**
         * Here we s
         */
        if (paramServerConfiguration == null) {
            paramServerConfiguration = VoidConfiguration.builder()
                    .numberOfShards(2).unicastPort(40123).multicastPort(40124).build();
            paramServerConfiguration.setFaultToleranceStrategy(FaultToleranceStrategy.NONE);
        }

        isAutoDiscoveryMode = paramServerConfiguration.getShardAddresses() != null
                        && !paramServerConfiguration.getShardAddresses().isEmpty() ? false : true;

        Broadcast<VoidConfiguration> paramServerConfigurationBroadcast = null;

        if (isAutoDiscoveryMode) {
            log.info("Trying auto discovery mode...");

            elementsFreqAccumExtra = corpus.context().accumulator(new ExtraCounter<Long>(),
                            new ExtraElementsFrequenciesAccumulator());

            ExtraCountFunction<T> elementsCounter =
                            new ExtraCountFunction<>(elementsFreqAccumExtra, configuration.isTrainSequenceVectors());

            JavaRDD<Pair<Sequence<T>, Long>> countedCorpus = corpus.map(elementsCounter);

            // just to trigger map function, since we need huffman tree before proceeding
            numberOfSequences = countedCorpus.count();

            finalCounter = elementsFreqAccumExtra.value();

            ExtraCounter<Long> spareReference = (ExtraCounter<Long>) finalCounter;

            // getting list of available hosts
            Set<NetworkInformation> availableHosts = spareReference.getNetworkInformation();

            log.info("availableHosts: {}", availableHosts);
            if (availableHosts.size() > 1) {
                // now we have to pick N shards and optionally N backup nodes, and pass them within configuration bean
                NetworkOrganizer organizer =
                                new NetworkOrganizer(availableHosts, paramServerConfiguration.getNetworkMask());

                paramServerConfiguration
                                .setShardAddresses(organizer.getSubset(paramServerConfiguration.getNumberOfShards()));

                // backup shards are optional
                if (paramServerConfiguration.getFaultToleranceStrategy() != FaultToleranceStrategy.NONE) {
                    paramServerConfiguration.setBackupAddresses(
                                    organizer.getSubset(paramServerConfiguration.getNumberOfShards(),
                                                    paramServerConfiguration.getShardAddresses()));
                }
            } else {
                // for single host (aka driver-only, aka spark-local) just run on loopback interface
                paramServerConfiguration.setShardAddresses(
                                Arrays.asList("127.0.0.1:" + paramServerConfiguration.getPortSupplier().getPort()));
                paramServerConfiguration.setFaultToleranceStrategy(FaultToleranceStrategy.NONE);
            }



            log.info("Got Shards so far: {}", paramServerConfiguration.getShardAddresses());

            // update ps configuration with real values where required
            paramServerConfiguration.setNumberOfShards(paramServerConfiguration.getShardAddresses().size());
            paramServerConfiguration.setUseHS(configuration.isUseHierarchicSoftmax());
            paramServerConfiguration.setUseNS(configuration.getNegative() > 0);

            paramServerConfigurationBroadcast = sc.broadcast(paramServerConfiguration);

        } else {

            // update ps configuration with real values where required
            paramServerConfiguration.setNumberOfShards(paramServerConfiguration.getShardAddresses().size());
            paramServerConfiguration.setUseHS(configuration.isUseHierarchicSoftmax());
            paramServerConfiguration.setUseNS(configuration.getNegative() > 0);

            paramServerConfigurationBroadcast = sc.broadcast(paramServerConfiguration);


            // set up freqs accumulator
            elementsFreqAccum = corpus.context().accumulator(new Counter<Long>(), new ElementsFrequenciesAccumulator());
            CountFunction<T> elementsCounter =
                            new CountFunction<>(configurationBroadcast, paramServerConfigurationBroadcast,
                                            elementsFreqAccum, configuration.isTrainSequenceVectors());

            // count all sequence elements and their sum
            JavaRDD<Pair<Sequence<T>, Long>> countedCorpus = corpus.map(elementsCounter);

            // just to trigger map function, since we need huffman tree before proceeding
            numberOfSequences = countedCorpus.count();

            // now we grab counter, which contains frequencies for all SequenceElements in corpus
            finalCounter = elementsFreqAccum.value();
        }

        long numberOfElements = (long) finalCounter.totalCount();

        long numberOfUniqueElements = finalCounter.size();

        log.info("Total number of sequences: {}; Total number of elements entries: {}; Total number of unique elements: {}",
                        numberOfSequences, numberOfElements, numberOfUniqueElements);

        /*
         build RDD of reduced SequenceElements, just get rid of labels temporary, stick to some numerical values,
         like index or hashcode. So we could reduce driver memory footprint
         */


        // build huffman tree, and update original RDD with huffman encoding info
        shallowVocabCache = buildShallowVocabCache(finalCounter);
        shallowVocabCacheBroadcast = sc.broadcast(shallowVocabCache);

        // FIXME: probably we need to reconsider this approach
        JavaRDD<T> vocabRDD = corpus
                        .flatMap(new VocabRddFunctionFlat<T>(configurationBroadcast, paramServerConfigurationBroadcast))
                        .distinct();
        vocabRDD.count();

        /**
         * now we initialize Shards with values. That call should be started from driver which is either Client or Shard in standalone mode.
         */
        VoidParameterServer.getInstance().init(paramServerConfiguration, new RoutedTransport(),
                        ela.getTrainingDriver());
        VoidParameterServer.getInstance().initializeSeqVec(configuration.getLayersSize(), (int) numberOfUniqueElements,
                        119, configuration.getLayersSize() / paramServerConfiguration.getNumberOfShards(),
                        paramServerConfiguration.isUseHS(), paramServerConfiguration.isUseNS());

        // proceed to training
        // also, training function is the place where we invoke ParameterServer
        TrainingFunction<T> trainer = new TrainingFunction<>(shallowVocabCacheBroadcast, configurationBroadcast,
                        paramServerConfigurationBroadcast);
        PartitionTrainingFunction<T> partitionTrainer = new PartitionTrainingFunction<>(shallowVocabCacheBroadcast,
                        configurationBroadcast, paramServerConfigurationBroadcast);

        if (configuration != null)
            for (int e = 0; e < configuration.getEpochs(); e++)
                corpus.foreachPartition(partitionTrainer);
        //corpus.foreach(trainer);


        // we're transferring vectors to ExportContainer
        JavaRDD<ExportContainer<T>> exportRdd =
                        vocabRDD.map(new DistributedFunction<T>(paramServerConfigurationBroadcast,
                                        configurationBroadcast, shallowVocabCacheBroadcast));

        // at this particular moment training should be pretty much done, and we're good to go for export
        if (exporter != null)
            exporter.export(exportRdd);

        // unpersist, if we've persisten corpus after all
        if (storageLevel != null)
            corpus.unpersist();

        log.info("Training finish, starting cleanup...");
        VoidParameterServer.getInstance().shutdown();
    }