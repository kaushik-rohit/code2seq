public void resetThreadContextLoader() {
        if (LoaderUtils.isContextLoaderAvailable() && isContextLoaderSaved) {
            LoaderUtils.setContextClassLoader(savedContextLoader);
            savedContextLoader = null;
            isContextLoaderSaved = false;
        }
    }