public String getHelp() {
		StringBuilder sb = new StringBuilder(data.size() * HELP_TEXT_LENGTH_PER_PARAM);

		sb.append("Required Parameters:");
		sb.append(HELP_TEXT_LINE_DELIMITER);

		for (Option o : data.values()) {
			sb.append(this.helpText(o));
		}
		sb.append(HELP_TEXT_LINE_DELIMITER);

		return sb.toString();
	}