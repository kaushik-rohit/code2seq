public void replace(T from, T to) throws IOException {
        List<T> copy = new ArrayList<>(data.getView());
        for (int i=0; i<copy.size(); i++) {
            if (copy.get(i).equals(from))
                copy.set(i,to);
        }
        data.replaceBy(copy);
    }