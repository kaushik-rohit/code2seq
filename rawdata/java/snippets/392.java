@View(name = "by_surrogate", map = "function(doc) { if(doc.surrogate && doc.principal) { emit(doc.principal, doc.surrogate) } }")
    public List<String> findByPrincipal(final String surrogate) {
        val view = createQuery("by_surrogate").key(surrogate);
        return db.queryView(view, String.class);
    }