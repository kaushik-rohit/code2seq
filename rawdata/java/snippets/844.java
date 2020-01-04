private Class<?> loadClass(String className) {
		Class<?> clazz = null;
		try {
			clazz = Class.forName(className, this.initialize, ClassUtil.getClassLoader());
		} catch (NoClassDefFoundError e) {
			// 由于依赖库导致的类无法加载，直接跳过此类
		} catch (UnsupportedClassVersionError e) {
			// 版本导致的不兼容的类，跳过
		} catch (Exception e) {
			throw new RuntimeException(e);
			// Console.error(e);
		}
		return clazz;
	}