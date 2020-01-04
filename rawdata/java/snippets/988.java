public static long sizeof(final Object obj) {
        if (null == obj || isSharedFlyweight(obj)) {
            return 0;
        }

        final IdentityHashMap visited = new IdentityHashMap(80000);

        try {
            return computeSizeof(obj, visited, CLASS_METADATA_CACHE);
        } catch (RuntimeException re) {
            // re.printStackTrace();//DEBUG
            return -1;
        } catch (NoClassDefFoundError ncdfe) {
            // BUG: throws "java.lang.NoClassDefFoundError: org.eclipse.core.resources.IWorkspaceRoot" when run in WSAD
            // 5
            // see
            // http://www.javaworld.com/javaforums/showflat.php?Cat=&Board=958763&Number=15235&page=0&view=collapsed&sb=5&o=
            // System.err.println(ncdfe);//DEBUG
            return -1;
        }
    }