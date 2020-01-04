private List<String> getSourceDirsOnWindowsWithDriveLetters() {
		List<String> driveLetters = asList("C");
		try {
			driveLetters = OsUtils.getDrivesOnWindows();
		} catch (Throwable ignore) {
			ignore.printStackTrace();
		}
		List<String> sourceDirs = new ArrayList<String>();
		for (String letter : driveLetters) {
			for (String possibleSource : descriptor.getSourceDirsOnWindows()) {
				if (!isDriveSpecificOnWindows(possibleSource)) {
					sourceDirs.add(letter + ":" + possibleSource);
				}
			}
		}
		for (String possibleSource : descriptor.getSourceDirsOnWindows()) {
			if (isDriveSpecificOnWindows(possibleSource)) sourceDirs.add(possibleSource);
		}
		
		return sourceDirs;
	}