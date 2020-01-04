public static <T> int binarySearch(List<? extends Comparable<? super T>> sortedList, T key) {
		return Collections.binarySearch(sortedList, key);
	}