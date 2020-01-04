@SneakyThrows
    public static <T> T deserialize(final InputStream inputStream, final Class<T> clazz) {
        try (val in = new ObjectInputStream(inputStream)) {
            val obj = in.readObject();

            if (!clazz.isAssignableFrom(obj.getClass())) {
                throw new ClassCastException("Result [" + obj
                    + " is of type " + obj.getClass()
                    + " when we were expecting " + clazz);
            }
            return (T) obj;
        }
    }