public static AntClassLoader newAntClassLoader(ClassLoader parent,
                                                   Project project,
                                                   Path path,
                                                   boolean parentFirst) {
        if (subClassToLoad != null) {
            return (AntClassLoader)
                ReflectUtil.newInstance(subClassToLoad,
                                        CONSTRUCTOR_ARGS,
                                        new Object[] {
                                            parent, project, path, parentFirst
                                        });
        }
        return new AntClassLoader(parent, project, path, parentFirst);
    }