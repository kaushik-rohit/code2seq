public void showSpiderDialog(Target target) {
		if (spiderDialog == null) {
			spiderDialog = new SpiderDialog(this, View.getSingleton().getMainFrame(), new Dimension(700, 430));
		}
		if (spiderDialog.isVisible()) {
			// Its behind you! Actually not needed no the window is alwaysOnTop, but keeping in case we change that ;)
			spiderDialog.toFront();
			return;
		}
		if (target != null) {
			spiderDialog.init(target);
		} else {
			// Keep the previous target
			spiderDialog.init(null);
		}
		spiderDialog.setVisible(true);
	}