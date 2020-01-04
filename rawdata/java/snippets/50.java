public int performRecovery() throws Exception {
        long traceId = LoggerHelpers.traceEnterWithContext(log, this.traceObjectId, "performRecovery");
        Timer timer = new Timer();
        log.info("{} Recovery started.", this.traceObjectId);

        // Put metadata (and entire container) into 'Recovery Mode'.
        this.metadata.enterRecoveryMode();

        // Reset metadata.
        this.metadata.reset();

        OperationMetadataUpdater metadataUpdater = new OperationMetadataUpdater(this.metadata);
        this.stateUpdater.enterRecoveryMode(metadataUpdater);

        boolean successfulRecovery = false;
        int recoveredItemCount;
        try {
            recoveredItemCount = recoverAllOperations(metadataUpdater);
            this.metadata.setContainerEpoch(this.durableDataLog.getEpoch());
            log.info("{} Recovery completed. Epoch = {}, Items Recovered = {}, Time = {}ms.", this.traceObjectId,
                    this.metadata.getContainerEpoch(), recoveredItemCount, timer.getElapsedMillis());
            successfulRecovery = true;
        } finally {
            // We must exit recovery mode when done, regardless of outcome.
            this.metadata.exitRecoveryMode();
            this.stateUpdater.exitRecoveryMode(successfulRecovery);
        }

        LoggerHelpers.traceLeave(log, this.traceObjectId, "performRecovery", traceId);
        return recoveredItemCount;
    }