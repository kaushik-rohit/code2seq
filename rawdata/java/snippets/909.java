public void setInputLocalStrategy(int inputNum, LocalStrategy strategy) {
		this.config.setInteger(INPUT_LOCAL_STRATEGY_PREFIX + inputNum, strategy.ordinal());
	}