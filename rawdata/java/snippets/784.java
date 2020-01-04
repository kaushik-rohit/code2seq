public FilePath[] getModuleRoots(FilePath workspace, AbstractBuild build) {
        if (Util.isOverridden(SCM.class,getClass(),"getModuleRoots", FilePath.class))
            // if the subtype derives legacy getModuleRoots(FilePath), delegate to it
            return getModuleRoots(workspace);

        // otherwise the default implementation
        return new FilePath[]{getModuleRoot(workspace,build)};
    }