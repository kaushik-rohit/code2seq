public boolean contains(String group, Collection<String> values) {
		final LinkedHashSet<String> valueSet = getValues(group);
		if (CollectionUtil.isEmpty(values) || CollectionUtil.isEmpty(valueSet)) {
			return false;
		}

		return valueSet.containsAll(values);
	}