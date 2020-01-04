public String decode(String morse) {
		Assert.notNull(morse, "Morse should not be null.");

		final char dit = this.dit;
		final char dah = this.dah;
		final char split = this.split;
		if (false == StrUtil.containsOnly(morse, dit, dah, split)) {
			throw new IllegalArgumentException("Incorrect morse.");
		}
		final List<String> words = StrUtil.split(morse, split);
		final StringBuilder textBuilder = new StringBuilder();
		Integer codePoint;
		for (String word : words) {
			if(StrUtil.isEmpty(word)){
				continue;
			}
			word = word.replace(dit, '0').replace(dah, '1');
			codePoint = dictionaries.get(word);
			if (codePoint == null) {
				codePoint = Integer.valueOf(word, 2);
			}
			textBuilder.appendCodePoint(codePoint);
		}
		return textBuilder.toString();
	}