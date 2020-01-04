private static void addPanel(TabbedPanel2 tabbedPanel, AbstractPanel panel, boolean visible) {
		if (visible) {
			tabbedPanel.addTab(panel);
		} else {
			tabbedPanel.addTabHidden(panel);
		}
	}