private JCheckBox getHandleODataSpecificParameters() {
		if (handleODataSpecificParameters == null) {
			handleODataSpecificParameters = new JCheckBox();
			handleODataSpecificParameters.setText(Constant.messages.getString("spider.options.label.handlehodataparameters"));
		}
		return handleODataSpecificParameters;
	}