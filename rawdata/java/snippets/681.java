private void checkAndEnableViewButton() {
		boolean enabled = true;
		enabled &= Desktop.isDesktopSupported();
		enabled &= txt_PubCert.getDocument().getLength() > MIN_CERT_LENGTH;
		bt_view.setEnabled(enabled);
	}