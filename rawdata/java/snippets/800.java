private static int getProcessPiece() {
		// 进程码
		// 因为静态变量类加载可能相同,所以要获取进程ID + 加载对象的ID值
		final int processPiece;
		// 进程ID初始化
		int processId;
		try {
			// 获取进程ID
			final String processName =ManagementFactory.getRuntimeMXBean().getName();
			final int atIndex = processName.indexOf('@');
			if (atIndex > 0) {
				processId = Integer.parseInt(processName.substring(0, atIndex));
			} else {
				processId = processName.hashCode();
			}
		} catch (Throwable t) {
			processId = RandomUtil.randomInt();
		}

		final ClassLoader loader = ClassLoaderUtil.getClassLoader();
		// 返回对象哈希码,无论是否重写hashCode方法
		int loaderId = (loader != null) ? System.identityHashCode(loader) : 0;

		// 进程ID + 对象加载ID
		StringBuilder processSb = new StringBuilder();
		processSb.append(Integer.toHexString(processId));
		processSb.append(Integer.toHexString(loaderId));
		// 保留前2位
		processPiece = processSb.toString().hashCode() & 0xFFFF;

		return processPiece;
	}