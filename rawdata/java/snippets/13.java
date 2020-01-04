public static List<String> getFieldNames(Class<? extends Enum<?>> clazz) {
		final List<String> names = new ArrayList<>();
		final Field[] fields = ReflectUtil.getFields(clazz);
		String name;
		for (Field field : fields) {
			name = field.getName();
			if (field.getType().isEnum() || name.contains("$VALUES") || "ordinal".equals(name)) {
				continue;
			}
			if(false == names.contains(name)) {
				names.add(name);
			}
		}
		return names;
	}