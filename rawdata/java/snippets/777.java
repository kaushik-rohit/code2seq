public Object call(Long nid, final Event event) {
        return delegate.call(convertToAddress(nid), event);
    }