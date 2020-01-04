public static GroovyObject parseGroovyScript(final Resource groovyScript,
                                                 final boolean failOnError) {
        return AccessController.doPrivileged((PrivilegedAction<GroovyObject>) () -> {
            val parent = ScriptingUtils.class.getClassLoader();
            try (val loader = new GroovyClassLoader(parent)) {
                val groovyFile = groovyScript.getFile();
                if (groovyFile.exists()) {
                    val groovyClass = loader.parseClass(groovyFile);
                    LOGGER.trace("Creating groovy object instance from class [{}]", groovyFile.getCanonicalPath());
                    return (GroovyObject) groovyClass.getDeclaredConstructor().newInstance();
                }
                LOGGER.trace("Groovy script at [{}] does not exist", groovyScript);
            } catch (final Exception e) {
                if (failOnError) {
                    throw new RuntimeException(e);
                }
                LOGGER.error(e.getMessage(), e);
            }
            return null;
        });
    }