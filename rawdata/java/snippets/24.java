@Override
    public List<Application> getSortedApplications() {
        List<Application> apps = new ArrayList<Application>(getApplications().getRegisteredApplications());
        Collections.sort(apps, APP_COMPARATOR);
        return apps;
    }