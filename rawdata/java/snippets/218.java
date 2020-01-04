@Nullable
  public static List<DruidExpression> toDruidExpressions(
      final PlannerContext plannerContext,
      final RowSignature rowSignature,
      final List<RexNode> rexNodes
  )
  {
    final List<DruidExpression> retVal = new ArrayList<>(rexNodes.size());
    for (RexNode rexNode : rexNodes) {
      final DruidExpression druidExpression = toDruidExpression(plannerContext, rowSignature, rexNode);
      if (druidExpression == null) {
        return null;
      }

      retVal.add(druidExpression);
    }
    return retVal;
  }