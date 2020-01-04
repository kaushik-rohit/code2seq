protected JComboBox<SessionManagementMethodType> getSessionManagementMethodsComboBox() {
		if (sessionManagementMethodsComboBox == null) {
			Vector<SessionManagementMethodType> methods = new Vector<>(
					extension.getSessionManagementMethodTypes());
			sessionManagementMethodsComboBox = new JComboBox<>(methods);
			sessionManagementMethodsComboBox.setSelectedItem(null);

			// Prepare the listener for the change of selection
			sessionManagementMethodsComboBox.addItemListener(new ItemListener() {

				@Override
				public void itemStateChanged(ItemEvent e) {
					if (e.getStateChange() == ItemEvent.SELECTED) {
						// Prepare the new session management method
						log.debug("Selected new Session Management type: " + e.getItem());
						SessionManagementMethodType type = ((SessionManagementMethodType) e.getItem());

						// If no session management method was previously selected or it's a
						// different class, create it now
						if (selectedMethod == null || !type.isTypeForMethod(selectedMethod)) {
							// Create the new session management method
							selectedMethod = type.createSessionManagementMethod(getContextIndex());
						}

						// Show the status panel and configuration button, if needed
						changeMethodConfigPanel(type);
						if (type.hasOptionsPanel())
							shownConfigPanel.bindMethod(selectedMethod);
					}
				}
			});
		}
		return sessionManagementMethodsComboBox;

	}