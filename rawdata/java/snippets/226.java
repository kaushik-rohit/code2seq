@Override
	public void computeUnclosedBranchStack() {
		if (this.openBranches != null) {
			return;
		}

		addClosedBranches(getPredecessorNode().closedBranchingNodes);
		List<UnclosedBranchDescriptor> fromInput = getPredecessorNode().getBranchesForParent(this.inConn);
		
		// handle the data flow branching for the broadcast inputs
		List<UnclosedBranchDescriptor> result = computeUnclosedBranchStackForBroadcastInputs(fromInput);
		
		this.openBranches = (result == null || result.isEmpty()) ? Collections.<UnclosedBranchDescriptor>emptyList() : result;
	}