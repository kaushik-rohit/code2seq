protected void applyOverrides(Alert alert) {
        if (this.alertOverrides.isEmpty()) {
            // Nothing to do
            return;
        }
        String changedName = this.alertOverrides.getProperty(alert.getPluginId() + ".name");
        if (changedName != null) {
            alert.setName(applyOverride(alert.getName(), changedName));
        }
        String changedDesc = this.alertOverrides.getProperty(alert.getPluginId() + ".description");
        if (changedDesc != null) {
            alert.setDescription(applyOverride(alert.getDescription(), changedDesc));
        }
        String changedSolution = this.alertOverrides.getProperty(alert.getPluginId() + ".solution");
        if (changedSolution != null) {
            alert.setSolution(applyOverride(alert.getSolution(), changedSolution));
        }
        String changedOther = this.alertOverrides.getProperty(alert.getPluginId() + ".otherInfo");
        if (changedOther != null) {
            alert.setOtherInfo(applyOverride(alert.getOtherInfo(), changedOther));
        }
        String changedReference = this.alertOverrides.getProperty(alert.getPluginId() + ".reference");
        if (changedReference != null) {
            alert.setReference(applyOverride(alert.getReference(), changedReference));
        }
    }