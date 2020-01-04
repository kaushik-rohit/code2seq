public String between(Date date, DateUnit unit, BetweenFormater.Level formatLevel) {
		return new DateBetween(this, date).toString(formatLevel);
	}