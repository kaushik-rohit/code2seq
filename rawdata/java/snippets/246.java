public List<WordInfo> discover(String doc, int size)
    {
        try
        {
            return discover(new BufferedReader(new StringReader(doc)), size);
        }
        catch (IOException e)
        {
            throw new RuntimeException(e);
        }
    }