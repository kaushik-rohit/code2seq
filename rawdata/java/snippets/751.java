private JButton getBtnDelete() {
		if (btnDelete == null) {
			btnDelete = new JButton();
			btnDelete.setText(Constant.messages.getString("history.managetags.button.delete"));
			btnDelete.setMinimumSize(new java.awt.Dimension(75,30));
			btnDelete.setPreferredSize(new java.awt.Dimension(75,30));
			btnDelete.setMaximumSize(new java.awt.Dimension(100,40));
			btnDelete.setEnabled(true);
			btnDelete.addActionListener(new java.awt.event.ActionListener() { 

				@Override
				public void actionPerformed(java.awt.event.ActionEvent e) {
					deleteTags(tagList.getSelectedValuesList());
				}
			});

		}
		return btnDelete;
	}