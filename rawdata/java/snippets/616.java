private void setScanButtonsAndProgressBarStates(boolean isStarted, boolean isPaused,
			boolean allowStartScan) {
		if (isStarted) {
			getStartScanButton().setEnabled(false);
			getPauseScanButton().setEnabled(true);
			getPauseScanButton().setSelected(isPaused);
			getStopScanButton().setEnabled(true);
			getProgressBar().setEnabled(true);
		} else {
			getStartScanButton().setEnabled(allowStartScan);
			getStopScanButton().setEnabled(false);
			getPauseScanButton().setEnabled(false);
			getPauseScanButton().setSelected(false);
			getProgressBar().setEnabled(false);
		}
	}