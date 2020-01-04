public @Nullable LabelAtom getLabelAtom(@CheckForNull String name) {
        if (name==null)  return null;

        while(true) {
            Label l = labels.get(name);
            if(l!=null)
                return (LabelAtom)l;

            // non-existent
            LabelAtom la = new LabelAtom(name);
            if (labels.putIfAbsent(name, la)==null)
                la.load();
        }
    }