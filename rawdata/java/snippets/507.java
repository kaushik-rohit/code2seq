@Nonnull
    @Restricted(NoExternalUse.class)
    @SuppressWarnings("unused") // invoked from stapler view
    public List<View> sort(@Nonnull List<? extends View> views) {
        List<View> result = new ArrayList<>(views);
        result.sort(new Comparator<View>() {
            @Override
            public int compare(View o1, View o2) {
                return o1.getDisplayName().compareTo(o2.getDisplayName());
            }
        });
        return result;
    }