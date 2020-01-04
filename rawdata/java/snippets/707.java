private void scanFile(File file, String rootDir) {
		if (file.isFile()) {
			final String fileName = file.getAbsolutePath();
			if (fileName.endsWith(FileUtil.CLASS_EXT)) {
				final String className = fileName//
						// 8为classes长度，fileName.length() - 6为".class"的长度
						.substring(rootDir.length(), fileName.length() - 6)//
						.replace(File.separatorChar, CharUtil.DOT);//
				//加入满足条件的类
				addIfAccept(className);
			} else if (fileName.endsWith(FileUtil.JAR_FILE_EXT)) {
				try {
					scanJar(new JarFile(file));
				} catch (IOException e) {
					throw new IORuntimeException(e);
				}
			}
		} else if (file.isDirectory()) {
			for (File subFile : file.listFiles()) {
				scanFile(subFile, (null == rootDir) ? subPathBeforePackage(file) : rootDir);
			}
		}
	}