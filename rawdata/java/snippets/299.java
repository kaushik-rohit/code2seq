public synchronized void single(long weight) throws InterruptedException {
        this.weights.remove(weight);
        // 触发下一个可运行的weight
        Long nextWeight = this.weights.peek();
        if (nextWeight != null) {
            barrier.single(nextWeight);
        }
    }