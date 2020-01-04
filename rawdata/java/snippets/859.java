public TableOperation createSort(List<Expression> orders, TableOperation child) {
		failIfStreaming();

		List<Expression> convertedOrders = orders.stream()
			.map(f -> f.accept(orderWrapper))
			.collect(Collectors.toList());
		return new SortTableOperation(convertedOrders, child);
	}