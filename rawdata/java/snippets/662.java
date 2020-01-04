private RelBuilder createSelectDistinct(RelBuilder relBuilder,
			Aggregate aggregate, List<Integer> argList, int filterArg,
			Map<Integer, Integer> sourceOf) {
		relBuilder.push(aggregate.getInput());
		final List<Pair<RexNode, String>> projects = new ArrayList<>();
		final List<RelDataTypeField> childFields =
				relBuilder.peek().getRowType().getFieldList();
		for (int i : aggregate.getGroupSet()) {
			sourceOf.put(i, projects.size());
			projects.add(RexInputRef.of2(i, childFields));
		}
		if (filterArg >= 0) {
			sourceOf.put(filterArg, projects.size());
			projects.add(RexInputRef.of2(filterArg, childFields));
		}
		for (Integer arg : argList) {
			if (filterArg >= 0) {
				// Implement
				//   agg(DISTINCT arg) FILTER $f
				// by generating
				//   SELECT DISTINCT ... CASE WHEN $f THEN arg ELSE NULL END AS arg
				// and then applying
				//   agg(arg)
				// as usual.
				//
				// It works except for (rare) agg functions that need to see null
				// values.
				final RexBuilder rexBuilder = aggregate.getCluster().getRexBuilder();
				final RexInputRef filterRef = RexInputRef.of(filterArg, childFields);
				final Pair<RexNode, String> argRef = RexInputRef.of2(arg, childFields);
				RexNode condition =
						rexBuilder.makeCall(SqlStdOperatorTable.CASE, filterRef,
								argRef.left,
								rexBuilder.ensureType(argRef.left.getType(),
										rexBuilder.makeCast(argRef.left.getType(),
												rexBuilder.constantNull()),
										true));
				sourceOf.put(arg, projects.size());
				projects.add(Pair.of(condition, "i$" + argRef.right));
				continue;
			}
			if (sourceOf.get(arg) != null) {
				continue;
			}
			sourceOf.put(arg, projects.size());
			projects.add(RexInputRef.of2(arg, childFields));
		}
		relBuilder.project(Pair.left(projects), Pair.right(projects));

		// Get the distinct values of the GROUP BY fields and the arguments
		// to the agg functions.
		relBuilder.push(
				aggregate.copy(aggregate.getTraitSet(), relBuilder.build(), false,
						ImmutableBitSet.range(projects.size()),
						null, com.google.common.collect.ImmutableList.<AggregateCall>of()));
		return relBuilder;
	}