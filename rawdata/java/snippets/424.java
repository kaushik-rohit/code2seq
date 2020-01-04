public void startThreads() {
		if (this.sortThread != null) {
			this.sortThread.start();
		}
		if (this.spillThread != null) {
			this.spillThread.start();
		}
		if (this.mergeThread != null) {
			this.mergeThread.start();
		}
	}