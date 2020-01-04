public DocumentDbTemplate createDocumentDbTemplate(final DocumentDbFactory documentDbFactory,
                                                       final BaseCosmosDbProperties properties) {
        val documentDbMappingContext = createDocumentDbMappingContext();
        val mappingDocumentDbConverter = createMappingDocumentDbConverter(documentDbMappingContext);
        return new DocumentDbTemplate(documentDbFactory, mappingDocumentDbConverter, properties.getDatabase());
    }