public void setClassPath(Path classpath) {
        pathComponents.removeAllElements();
        if (classpath != null) {
            Path actualClasspath = classpath.concatSystemClasspath("ignore");
            String[] pathElements = actualClasspath.list();
            for (int i = 0; i < pathElements.length; ++i) {
                try {
                    addPathElement(pathElements[i]);
                } catch (BuildException e) {
                    // ignore path elements which are invalid
                    // relative to the project
                }
            }
        }
    }