public void rebuildHetero(StaplerRequest req, JSONObject formData, Collection<? extends Descriptor<T>> descriptors, String key) throws FormException, IOException {
        replaceBy(Descriptor.newInstancesFromHeteroList(req,formData,key,descriptors));
    }