private void formatHeaderAndFooter(int itemCount, int id) {
        // Header.
        this.header.set(VERSION_OFFSET, CURRENT_VERSION);
        this.header.set(FLAGS_OFFSET, getFlags(this.config.isIndexPage ? FLAG_INDEX_PAGE : FLAG_NONE));
        setHeaderId(id);
        setCount(itemCount);

        // Matching footer.
        setFooterId(id);
    }