public static CellStyle createDefaultCellStyle(Workbook workbook) {
		final CellStyle cellStyle = workbook.createCellStyle();
		setAlign(cellStyle, HorizontalAlignment.CENTER, VerticalAlignment.CENTER);
		setBorder(cellStyle, BorderStyle.THIN, IndexedColors.BLACK);
		return cellStyle;
	}