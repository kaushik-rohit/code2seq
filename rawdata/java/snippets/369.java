public void load(ObjectInputStream in, V[] value) throws IOException, ClassNotFoundException
    {
        base = (int[]) in.readObject();
        check = (int[]) in.readObject();
        fail = (int[]) in.readObject();
        output = (int[][]) in.readObject();
        l = (int[]) in.readObject();
        v = value;
    }