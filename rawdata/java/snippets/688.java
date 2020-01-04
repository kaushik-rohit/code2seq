public static Set<Stubbing> findStubbings(Iterable<?> mocks) {
        Set<Stubbing> stubbings = new TreeSet<Stubbing>(new StubbingComparator());
        for (Object mock : mocks) {
            Collection<? extends Stubbing> fromSingleMock = new DefaultMockingDetails(mock).getStubbings();
            stubbings.addAll(fromSingleMock);
        }

        return stubbings;
    }