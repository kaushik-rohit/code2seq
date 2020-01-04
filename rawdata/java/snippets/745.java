@View(name = "size", map = "function(doc) { if (doc.service) { emit(doc, doc._id) }}", reduce = "_count")
    public int size() {
        val r = db.queryView(createQuery("size"));
        LOGGER.trace("r.isEmpty [{}]", r.isEmpty());
        LOGGER.trace("r.getRows [{}]", r.getRows());
        if (r.isEmpty()) {
            return 0;
        }

        return r.getRows().get(0).getValueAsInt();
    }