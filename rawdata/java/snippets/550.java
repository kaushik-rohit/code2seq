private  void initialize(ImageIcon icon) {
        this.setLayout(new CardLayout());
        if (Model.getSingleton().getOptionsParam().getViewParam().getWmUiHandlingOption() == 0) {
        	this.setSize(474, 251);
        }
        this.setName(Constant.messages.getString(prefix + ".panel.title"));
		this.setIcon(icon);
        this.add(getPanelCommand(), prefix + ".panel");
        scanStatus = new ScanStatus(icon, Constant.messages.getString(prefix + ".panel.title"));
        
        if (View.isInitialised()) {
        	View.getSingleton().getMainFrame().getMainFooterPanel().addFooterToolbarRightLabel(scanStatus.getCountLabel());
        }
	}