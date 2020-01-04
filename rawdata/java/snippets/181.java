@SuppressWarnings("unchecked")
    public final void remove(InternalThreadLocalMap threadLocalMap) {
        if (threadLocalMap == null) {
            return;
        }

        Object v = threadLocalMap.removeIndexedVariable(index);
        removeFromVariablesToRemove(threadLocalMap, this);

        if (v != InternalThreadLocalMap.UNSET) {
            try {
                onRemoval((V) v);
            } catch (Exception e) {
                PlatformDependent.throwException(e);
            }
        }
    }