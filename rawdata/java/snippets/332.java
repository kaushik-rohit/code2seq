public void setBroadcastInputs(Map<Operator<?>, OptimizerNode> operatorToNode, ExecutionMode defaultExchangeMode) {
		// skip for Operators that don't support broadcast variables 
		if (!(getOperator() instanceof AbstractUdfOperator<?, ?>)) {
			return;
		}

		// get all broadcast inputs
		AbstractUdfOperator<?, ?> operator = ((AbstractUdfOperator<?, ?>) getOperator());

		// create connections and add them
		for (Map.Entry<String, Operator<?>> input : operator.getBroadcastInputs().entrySet()) {
			OptimizerNode predecessor = operatorToNode.get(input.getValue());
			DagConnection connection = new DagConnection(predecessor, this,
															ShipStrategyType.BROADCAST, defaultExchangeMode);
			addBroadcastConnection(input.getKey(), connection);
			predecessor.addOutgoingConnection(connection);
		}
	}