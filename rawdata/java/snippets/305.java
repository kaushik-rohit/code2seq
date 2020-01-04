public static int epollBusyWait(FileDescriptor epollFd, EpollEventArray events) throws IOException {
        int ready = epollBusyWait0(epollFd.intValue(), events.memoryAddress(), events.length());
        if (ready < 0) {
            throw newIOException("epoll_wait", ready);
        }
        return ready;
    }