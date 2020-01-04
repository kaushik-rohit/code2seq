public <T extends Pointer> T getHelperWorkspace(String key){
        return helperWorkspacePointers == null ? null : (T)helperWorkspacePointers.get(key);
    }