public VoidAggregation unpin(@NonNull VoidAggregation aggregation) {
        return unpin(aggregation.getOriginatorId(), aggregation.getTaskId());
    }