private void setFuzzerOptin(boolean shouldOptin) {
        if (shouldOptin) {
            PassiveScanThread.addApplicableHistoryType(HistoryReference.TYPE_FUZZER);
            PassiveScanThread.addApplicableHistoryType(HistoryReference.TYPE_FUZZER_TEMPORARY);
        } else {
            PassiveScanThread.removeApplicableHistoryType(HistoryReference.TYPE_FUZZER);
            PassiveScanThread.removeApplicableHistoryType(HistoryReference.TYPE_FUZZER_TEMPORARY);
        }
    }