public static List<Method> getAllMethods(Class clazz) {
        List<Method> all = new ArrayList<Method>();
        for (Class<?> c = clazz; c != Object.class && c != null; c = c.getSuperclass()) {
            Method[] methods = c.getDeclaredMethods(); // 所有方法，不包含父类
            for (Method method : methods) {
                int mod = method.getModifiers();
                // native的不要
                if (Modifier.isNative(mod)) {
                    continue;
                }
                method.setAccessible(true); // 不管private还是protect都可以
                all.add(method);
            }
        }
        return all;
    }