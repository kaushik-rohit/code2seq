public static Row getOrCreateRow(Sheet sheet, int rowIndex) {
		Row row = sheet.getRow(rowIndex);
		if (null == row) {
			row = sheet.createRow(rowIndex);
		}
		return row;
	}