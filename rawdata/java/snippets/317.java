public Long peek() throws InterruptedException {
        lock.lockInterruptibly();
        try {
            while (queue.size() == 0) {
                notEmpty.await();
            }

            return queue.peek();
        } finally {
            lock.unlock();
        }
    }