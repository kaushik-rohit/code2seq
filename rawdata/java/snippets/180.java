public void add(E element) throws IllegalStateException {
		requireNonNull(element);

		lock.lock();
		try {
			if (open) {
				elements.addLast(element);
				if (elements.size() == 1) {
					nonEmpty.signalAll();
				}
			} else {
				throw new IllegalStateException("queue is closed");
			}
		} finally {
			lock.unlock();
		}
	}