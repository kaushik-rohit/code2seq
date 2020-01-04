private JPanel getJPanel1() {
		if (jPanel1 == null) {
			jPanel1 = new JPanel();
			jPanel1.setLayout(new CardLayout());
			jPanel1.add(getJScrollPane(), getJScrollPane().getName());
		}
		return jPanel1;
	}