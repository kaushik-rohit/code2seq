public static <T> Iterable<T> wrap(final Iterable<T> base) {
        return new Iterable<T>() {
            public Iterator<T> iterator() {
                final Iterator<T> itr = base.iterator();
                return new Iterator<T>() {
                    public boolean hasNext() {
                        return itr.hasNext();
                    }

                    public T next() {
                        return itr.next();
                    }

                    public void remove() {
                        itr.remove();
                    }
                };
            }
        };
    }