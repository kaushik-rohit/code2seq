public HttpHeaders preflightResponseHeaders() {
        if (preflightHeaders.isEmpty()) {
            return EmptyHttpHeaders.INSTANCE;
        }
        final HttpHeaders preflightHeaders = new DefaultHttpHeaders();
        for (Entry<CharSequence, Callable<?>> entry : this.preflightHeaders.entrySet()) {
            final Object value = getValue(entry.getValue());
            if (value instanceof Iterable) {
                preflightHeaders.add(entry.getKey(), (Iterable<?>) value);
            } else {
                preflightHeaders.add(entry.getKey(), value);
            }
        }
        return preflightHeaders;
    }