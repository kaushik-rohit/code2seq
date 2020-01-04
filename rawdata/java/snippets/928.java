public static StreamTruncationRecord complete(StreamTruncationRecord toComplete) {
        Preconditions.checkState(toComplete.updating);
        ImmutableSet.Builder<Long> builder = ImmutableSet.builder();
        
        builder.addAll(toComplete.deletedSegments);
        builder.addAll(toComplete.toDelete);

        return StreamTruncationRecord.builder()
                                     .updating(false)
                                     .span(toComplete.span)
                                     .streamCut(toComplete.streamCut)
                                     .deletedSegments(builder.build())
                                     .toDelete(ImmutableSet.of())
                                     .sizeTill(toComplete.sizeTill)
                                     .build();
    }