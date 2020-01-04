private PopupFindMenu getPopupMenuFind() {
        if (popupFindMenu== null) {
            popupFindMenu = new PopupFindMenu();
            popupFindMenu.setText(Constant.messages.getString("edit.find.popup"));	// ZAP: i18n
            popupFindMenu.addActionListener(new java.awt.event.ActionListener() {
                @Override
                public void actionPerformed(java.awt.event.ActionEvent e) {
                    JTextComponent component = popupFindMenu.getLastInvoker();
                    Window window = getWindowAncestor(component);
                    if (window != null) {
                        showFindDialog(window, component);
                    }
                }
            });
        }
        return popupFindMenu;
    }