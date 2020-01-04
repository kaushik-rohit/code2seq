public HttpSession getSelectedSession() {
		final int selectedRow = this.sessionsTable.getSelectedRow();
		if (selectedRow == -1) {
			// No row selected
			return null;
		}
		final int rowIndex = sessionsTable.convertRowIndexToModel(selectedRow);
		return this.sessionsModel.getHttpSessionAt(rowIndex);
	}