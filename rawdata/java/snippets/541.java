public static DecryptionTool make(DecryptionSetup ds) {
    if (ds._decrypt_tool_id == null)
      ds._decrypt_tool_id = Key.make();
    try {
      Class<?> dtClass = DecryptionTool.class.getClassLoader().loadClass(ds._decrypt_impl);
      if (! DecryptionTool.class.isAssignableFrom(dtClass)) {
        throw new IllegalArgumentException("Class " + ds._decrypt_impl + " doesn't implement a Decryption Tool.");
      }
      Constructor<?> constructor = dtClass.getConstructor(DecryptionSetup.class);
      DecryptionTool dt = (DecryptionTool) constructor.newInstance(ds);
      DKV.put(dt);
      return dt;
    } catch (ClassNotFoundException e) {
      throw new RuntimeException("Unknown decrypt tool: " + ds._decrypt_impl, e);
    } catch (NoSuchMethodException e) {
      throw new RuntimeException("Invalid implementation of Decryption Tool (missing constructor).", e);
    } catch (Exception e) {
      throw new RuntimeException(e);
    }
  }