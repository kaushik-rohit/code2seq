public boolean load(String path)
    {
        String binPath = path + Predefine.BIN_EXT;
        if (load(ByteArrayStream.createByteArrayStream(binPath))) return true;
        if (!loadTxt(path)) return false;
        try
        {
            logger.info("正在缓存" + binPath);
            DataOutputStream out = new DataOutputStream(IOUtil.newOutputStream(binPath));
            save(out);
            out.close();
        }
        catch (Exception e)
        {
            logger.warning("缓存" + binPath + "失败：\n" + TextUtility.exceptionToString(e));
        }

        return true;
    }