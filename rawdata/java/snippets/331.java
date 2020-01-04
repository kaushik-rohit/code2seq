@Nonnull
    public InstallState getInstallState() {
        if (installState != null) {
            installStateName = installState.name();
            installState = null;
        }
        InstallState is = installStateName != null ? InstallState.valueOf(installStateName) : InstallState.UNKNOWN;
        return is != null ? is : InstallState.UNKNOWN;
    }