private void addPkcs11ButtonActionPerformed(java.awt.event.ActionEvent evt) {//GEN-FIRST:event_addPkcs11ButtonActionPerformed
		String name = null;
		try {
			final int indexSelectedDriver = driverComboBox.getSelectedIndex();
			name = driverConfig.getNames().get(indexSelectedDriver);
			if (name.equals("")) {
				return;
			}

			String library = driverConfig.getPaths().get(indexSelectedDriver);
			if (library.equals("")) {
				return;
			}
			
			int slot = driverConfig.getSlots().get(indexSelectedDriver);
			if (slot < 0) {
				return;
			}
			
			int slotListIndex = driverConfig.getSlotIndexes().get(indexSelectedDriver);
			if (slotListIndex < 0) {
				return;
			}
			
			String kspass = new String(pkcs11PasswordField.getPassword());
			if (kspass.equals("")){
				kspass = null;
			}
			
			PCKS11ConfigurationBuilder confBuilder = PKCS11Configuration.builder();
			confBuilder.setName(name).setLibrary(library);
			if (usePkcs11ExperimentalSliSupportCheckBox.isSelected()) {
				confBuilder.setSlotListIndex(slotListIndex);
			} else {
				confBuilder.setSlotId(slot);
			}
			
			int ksIndex = contextManager.initPKCS11(confBuilder.build(), kspass);
			
			if (ksIndex == -1) {
				logger.error("The required PKCS#11 provider is not available ("
						+ SSLContextManager.SUN_PKCS11_CANONICAL_CLASS_NAME + " or "
						+ SSLContextManager.IBM_PKCS11_CONONICAL_CLASS_NAME + ").");
				showErrorMessageSunPkcs11ProviderNotAvailable();
				return;
			}
			
			// The PCKS11 driver/smartcard was initialized properly: reset login attempts
			login_attempts = 0;
			keyStoreListModel.insertElementAt(contextManager.getKeyStoreDescription(ksIndex), ksIndex);
			// Issue 182
			retry = true;

			certificatejTabbedPane.setSelectedIndex(0);
			activateFirstOnlyAliasOfKeyStore(ksIndex);

			driverComboBox.setSelectedIndex(-1);
			pkcs11PasswordField.setText("");
			
		} catch (InvocationTargetException e) {
			if (e.getCause() instanceof ProviderException) {
				if ("Error parsing configuration".equals(e.getCause().getMessage())) {
					// There was a problem with the configuration provided:
					//   - Missing library.
					//   - Malformed configuration.
					//   - ...
					logAndShowGenericErrorMessagePkcs11CouldNotBeAdded(false, name, e);
				} else if ("Initialization failed".equals(e.getCause().getMessage())) {
					// The initialisation may fail because of:
					//   - no smart card reader or smart card detected.
					//   - smart card is in use by other application.
					//   - ...
					
					// Issue 182: Try to instantiate the PKCS11 provider twice if there are
					// conflicts with other software (eg. Firefox), that is accessing it too.
					if (retry) {
						// Try two times only
						retry = false;
						addPkcs11ButtonActionPerformed(evt);
					} else {
						JOptionPane.showMessageDialog(null, new String[] {
								Constant.messages.getString("options.cert.error"),
								Constant.messages.getString("options.cert.error.pkcs11")}, 
								Constant.messages.getString("options.cert.label.client.cert"), JOptionPane.ERROR_MESSAGE);
						// Error message changed to explain that user should try to add it again... 
						retry = true;
						logger.warn("Couldn't add key from "+name, e);
					}
				} else {
					logAndShowGenericErrorMessagePkcs11CouldNotBeAdded(false, name, e);
				}
			} else {
				logAndShowGenericErrorMessagePkcs11CouldNotBeAdded(false, name, e);
			}
		} catch (java.io.IOException e) {
			if (e.getMessage().equals("load failed") && e.getCause().getClass().getName().equals("javax.security.auth.login.FailedLoginException")) {
				// Exception due to a failed login attempt: BAD PIN or password
				login_attempts++;
				String attempts = " ("+login_attempts+"/"+MAX_LOGIN_ATTEMPTS+") ";
				if (login_attempts == (MAX_LOGIN_ATTEMPTS-1)) {
					// Last attempt before blocking the smartcard
					JOptionPane.showMessageDialog(null, new String[] {
							Constant.messages.getString("options.cert.error"),
							Constant.messages.getString("options.cert.error.wrongpassword"), 
							Constant.messages.getString("options.cert.error.wrongpasswordlast"), attempts},
							Constant.messages.getString("options.cert.label.client.cert"), JOptionPane.ERROR_MESSAGE);
					logger.warn("PKCS#11: Incorrect PIN or password"+attempts+": "+name+" *LAST TRY BEFORE BLOCKING*");
				} else { 
					JOptionPane.showMessageDialog(null, new String[] {
							Constant.messages.getString("options.cert.error"),
							Constant.messages.getString("options.cert.error.wrongpassword"), attempts}, 
							Constant.messages.getString("options.cert.label.client.cert"), JOptionPane.ERROR_MESSAGE);
					logger.warn("PKCS#11: Incorrect PIN or password"+attempts+": "+name);
				}
			}else{
				logAndShowGenericErrorMessagePkcs11CouldNotBeAdded(false, name, e);
			}
		} catch (KeyStoreException e) {
			logAndShowGenericErrorMessagePkcs11CouldNotBeAdded(false, name, e);
		} catch (Exception e) {
			logAndShowGenericErrorMessagePkcs11CouldNotBeAdded(true, name, e);
		}


	}