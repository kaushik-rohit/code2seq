public Project getProject(final String name) {
    Project fetchedProject = this.projectsByName.get(name);
    if (fetchedProject == null) {
      try {
        fetchedProject = this.projectLoader.fetchProjectByName(name);
        if (fetchedProject != null) {
          logger.info("Project " + name + " not found in cache, fetched from DB.");
        } else {
          logger.info("No active project with name " + name + " exists in cache or DB.");
        }
      } catch (final ProjectManagerException e) {
        logger.error("Could not load project from store.", e);
      }
    }
    return fetchedProject;
  }