public SDVariable matchCondition(SDVariable in, Condition condition) {
        return new MatchConditionTransform(sameDiff(), in, condition).outputVariable();
    }