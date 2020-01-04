private JCheckBox getChkProxyOnly() {
		if (proxyOnlyCheckbox == null) {
			proxyOnlyCheckbox = new JCheckBox();
			proxyOnlyCheckbox.setText(Constant.messages.getString("httpsessions.options.label.proxyOnly"));
		}
		return proxyOnlyCheckbox;
	}