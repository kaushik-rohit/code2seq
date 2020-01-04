void lookupSelectHints(
		SqlSelect select,
		SqlParserPos pos,
		Collection<SqlMoniker> hintList) {
		IdInfo info = idPositions.get(pos.toString());
		if ((info == null) || (info.scope == null)) {
			SqlNode fromNode = select.getFrom();
			final SqlValidatorScope fromScope = getFromScope(select);
			lookupFromHints(fromNode, fromScope, pos, hintList);
		} else {
			lookupNameCompletionHints(info.scope, info.id.names,
				info.id.getParserPosition(), hintList);
		}
	}