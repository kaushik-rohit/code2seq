public static <T> TypeInformation<T> createHadoopWritableTypeInfo(Class<T> clazz) {
		checkNotNull(clazz);

		Class<?> typeInfoClass;
		try {
			typeInfoClass = Class.forName(HADOOP_WRITABLE_TYPEINFO_CLASS, false, TypeExtractor.class.getClassLoader());
		}
		catch (ClassNotFoundException e) {
			throw new RuntimeException("Could not load the TypeInformation for the class '"
					+ HADOOP_WRITABLE_CLASS + "'. You may be missing the 'flink-hadoop-compatibility' dependency.");
		}

		try {
			Constructor<?> constr = typeInfoClass.getConstructor(Class.class);

			@SuppressWarnings("unchecked")
			TypeInformation<T> typeInfo = (TypeInformation<T>) constr.newInstance(clazz);
			return typeInfo;
		}
		catch (NoSuchMethodException | IllegalAccessException | InstantiationException e) {
			throw new RuntimeException("Incompatible versions of the Hadoop Compatibility classes found.");
		}
		catch (InvocationTargetException e) {
			throw new RuntimeException("Cannot create Hadoop WritableTypeInfo.", e.getTargetException());
		}
	}