void storeInitialHashTable() throws IOException {
		if (spilled) {
			return; // we create the initialHashTable only once. Later calls are caused by deeper recursion lvls
		}
		spilled = true;
		
		for (int partIdx = 0; partIdx < initialPartitions.size(); partIdx++) {
			final ReOpenableHashPartition<BT, PT> p = (ReOpenableHashPartition<BT, PT>) initialPartitions.get(partIdx);
			if (p.isInMemory()) { // write memory resident partitions to disk
				this.writeBehindBuffersAvailable += p.spillInMemoryPartition(spilledInMemoryPartitions.next(), ioManager, writeBehindBuffers);
			}
		}
	}