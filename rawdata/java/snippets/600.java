public static List<String> getDrivesOnWindows() throws Throwable {
		loadWindowsDriveInfoLib();
		
		List<String> drives = new ArrayList<String>();
		
		WindowsDriveInfo info = new WindowsDriveInfo();
		for (String drive : info.getLogicalDrives()) {
			if (info.isFixedDisk(drive)) drives.add(drive);
		}
		
		return drives;
	}