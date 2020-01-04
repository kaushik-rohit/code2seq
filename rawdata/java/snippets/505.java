public static DescriptorExtensionList<BuildWrapper,Descriptor<BuildWrapper>> all() {
        // use getDescriptorList and not getExtensionList to pick up legacy instances
        return Jenkins.getInstance().<BuildWrapper,Descriptor<BuildWrapper>>getDescriptorList(BuildWrapper.class);
    }