public static boolean isSub(File parent, File sub) {
		Assert.notNull(parent);
		Assert.notNull(sub);
		return sub.toPath().startsWith(parent.toPath());
	}