public String getSheetName() {
		if (this.boundSheetRecords.size() > this.sheetIndex) {
			return this.boundSheetRecords.get(this.sheetIndex > -1 ? this.sheetIndex : this.curSheetIndex).getSheetname();
		}
		return null;
	}