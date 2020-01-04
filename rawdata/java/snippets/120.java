private void single(long timestamp) throws InterruptedException {
        lastTimestamps.add(timestamp);

        if (timestamp < state()) {
            // 针对mysql事务中会出现时间跳跃
            // 例子：
            // 2012-08-08 16:24:26 事务头
            // 2012-08-08 16:24:24 变更记录
            // 2012-08-08 16:24:25 变更记录
            // 2012-08-08 16:24:26　事务尾

            // 针对这种case，一旦发现timestamp有回退的情况，直接更新threshold，强制阻塞其他的操作，等待最小数据优先处理完成
            threshold = timestamp; // 更新为最小值
        }

        if (lastTimestamps.size() >= groupSize) {// 判断队列是否需要触发
            // 触发下一个出队列的数据
            Long minTimestamp = this.lastTimestamps.peek();
            if (minTimestamp != null) {
                threshold = minTimestamp;
                notify(minTimestamp);
            }
        } else {
            threshold = Long.MIN_VALUE;// 如果不满足队列长度，需要阻塞等待
        }
    }