public CompletableFuture<Void> addNewEntriesIfAbsent(String tableName, Map<String, byte[]> toAdd) {
        List<TableEntry<byte[], byte[]>> entries = toAdd.entrySet().stream().map(x ->
                new TableEntryImpl<>(new TableKeyImpl<>(x.getKey().getBytes(Charsets.UTF_8), KeyVersion.NOT_EXISTS), x.getValue()))
                                                        .collect(Collectors.toList());
        Supplier<String> errorMessage = () -> String.format("addNewEntriesIfAbsent: table: %s", tableName);
        return expectingDataExists(withRetries(() -> segmentHelper.updateTableEntries(tableName, entries, authToken.get(), 
                        RequestTag.NON_EXISTENT_ID), errorMessage)
                .handle((r, e) -> {
                    if (e != null) {
                        Throwable unwrap = Exceptions.unwrap(e);
                        if (unwrap instanceof StoreException.WriteConflictException) {
                            throw StoreException.create(StoreException.Type.DATA_EXISTS, errorMessage.get());
                        } else {
                            log.debug("add new entries to {} threw exception {} {}", tableName, unwrap.getClass(), unwrap.getMessage());
                            throw new CompletionException(e);
                        }
                    } else {
                        log.trace("entries added to table {}", tableName);
                        return null;
                    }
                }), null);
    }