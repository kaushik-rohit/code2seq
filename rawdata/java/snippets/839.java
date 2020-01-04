public void doSwitch() {
        AuthenticationInfo newRunningInfo = (runningInfo.equals(masterInfo) ? standbyInfo : masterInfo);
        this.doSwitch(newRunningInfo);
    }