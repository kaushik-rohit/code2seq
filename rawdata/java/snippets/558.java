protected Collector<OT> createSolutionSetUpdateOutputCollector(Collector<OT> delegate) {
		Broker<Object> solutionSetBroker = SolutionSetBroker.instance();

		Object ss = solutionSetBroker.get(brokerKey());
		if (ss instanceof CompactingHashTable) {
			@SuppressWarnings("unchecked")
			CompactingHashTable<OT> solutionSet = (CompactingHashTable<OT>) ss;
			return new SolutionSetUpdateOutputCollector<OT>(solutionSet, delegate);
		}
		else if (ss instanceof JoinHashMap) {
			@SuppressWarnings("unchecked")
			JoinHashMap<OT> map = (JoinHashMap<OT>) ss;
			return new SolutionSetObjectsUpdateOutputCollector<OT>(map, delegate);
		} else {
			throw new RuntimeException("Unrecognized solution set handle: " + ss);
		}
	}