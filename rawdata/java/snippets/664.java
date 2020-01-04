public void showParamPanel(String name) {
        if (name == null || name.equals("")) {
            return;
        }

        // exit if panel name not found. 
        AbstractParamPanel panel = tablePanel.get(name);
        if (panel == null) {
            return;
        }

        showParamPanel(panel, name);
    }