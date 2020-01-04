@DataBoundSetter
    @Restricted(NoExternalUse.class) // this is terrible enough without being used anywhere
    public void setChoices(Object choices) {
        if (choices instanceof String) {
            setChoicesText((String) choices);
            return;
        }
        if (choices instanceof List) {
            ArrayList<String> newChoices = new ArrayList<>();
            for (Object o : (List) choices) {
                if (o != null) {
                    newChoices.add(o.toString());
                }
            }
            this.choices = newChoices;
            return;
        }
        throw new IllegalArgumentException("expected String or List, but got " + choices.getClass().getName());
    }