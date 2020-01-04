public final List<AbstractProject> getBuildTriggerUpstreamProjects() {
        ArrayList<AbstractProject> result = new ArrayList<AbstractProject>();
        for (AbstractProject<?,?> ap : getUpstreamProjects()) {
            BuildTrigger buildTrigger = ap.getPublishersList().get(BuildTrigger.class);
            if (buildTrigger != null)
                if (buildTrigger.getChildJobs(ap).contains(this))
                    result.add(ap);
        }
        return result;
    }