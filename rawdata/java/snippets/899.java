private DbBatch getDbBatch(HttpPipeKey key) {
        String dataUrl = key.getUrl();
        Pipeline pipeline = configClientService.findPipeline(key.getIdentity().getPipelineId());
        DataRetriever dataRetriever = dataRetrieverFactory.createRetriever(pipeline.getParameters().getRetriever(),
            dataUrl,
            downloadDir);
        File archiveFile = null;
        try {
            dataRetriever.connect();
            dataRetriever.doRetrieve();
            archiveFile = dataRetriever.getDataAsFile();
        } catch (Exception e) {
            dataRetriever.abort();
            throw new PipeException("download_error", e);
        } finally {
            dataRetriever.disconnect();
        }

        // 处理下有加密的数据
        if (StringUtils.isNotEmpty(key.getKey()) && StringUtils.isNotEmpty(key.getCrc())) {
            decodeFile(archiveFile, key.getKey(), key.getCrc());
        }

        InputStream input = null;
        JSONReader reader = null;
        try {
            input = new BufferedInputStream(new FileInputStream(archiveFile));
            DbBatch dbBatch = new DbBatch();
            byte[] lengthBytes = new byte[4];
            input.read(lengthBytes);
            int length = ByteUtils.bytes2int(lengthBytes);
            BatchProto.RowBatch rowbatchProto = BatchProto.RowBatch.parseFrom(new LimitedInputStream(input, length));
            // 构造原始的model对象
            RowBatch rowBatch = new RowBatch();
            rowBatch.setIdentity(build(rowbatchProto.getIdentity()));
            for (BatchProto.RowData rowDataProto : rowbatchProto.getRowsList()) {
                EventData eventData = new EventData();
                eventData.setPairId(rowDataProto.getPairId());
                eventData.setTableId(rowDataProto.getTableId());
                eventData.setTableName(rowDataProto.getTableName());
                eventData.setSchemaName(rowDataProto.getSchemaName());
                eventData.setEventType(EventType.valuesOf(rowDataProto.getEventType()));
                eventData.setExecuteTime(rowDataProto.getExecuteTime());
                // add by ljh at 2012-10-31
                if (StringUtils.isNotEmpty(rowDataProto.getSyncMode())) {
                    eventData.setSyncMode(SyncMode.valuesOf(rowDataProto.getSyncMode()));
                }
                if (StringUtils.isNotEmpty(rowDataProto.getSyncConsistency())) {
                    eventData.setSyncConsistency(SyncConsistency.valuesOf(rowDataProto.getSyncConsistency()));
                }
                // 处理主键
                List<EventColumn> keys = new ArrayList<EventColumn>();
                for (BatchProto.Column columnProto : rowDataProto.getKeysList()) {
                    keys.add(buildColumn(columnProto));
                }
                eventData.setKeys(keys);
                // 处理old主键
                if (CollectionUtils.isEmpty(rowDataProto.getOldKeysList()) == false) {
                    List<EventColumn> oldKeys = new ArrayList<EventColumn>();
                    for (BatchProto.Column columnProto : rowDataProto.getOldKeysList()) {
                        oldKeys.add(buildColumn(columnProto));
                    }
                    eventData.setOldKeys(oldKeys);
                }
                // 处理具体的column value
                List<EventColumn> columns = new ArrayList<EventColumn>();
                for (BatchProto.Column columnProto : rowDataProto.getColumnsList()) {
                    columns.add(buildColumn(columnProto));
                }
                eventData.setColumns(columns);

                eventData.setRemedy(rowDataProto.getRemedy());
                eventData.setSize(rowDataProto.getSize());
                eventData.setSql(rowDataProto.getSql());
                eventData.setDdlSchemaName(rowDataProto.getDdlSchemaName());
                eventData.setHint(rowDataProto.getHint());
                eventData.setWithoutSchema(rowDataProto.getWithoutSchema());
                // 添加到总记录
                rowBatch.merge(eventData);
            }
            dbBatch.setRowBatch(rowBatch);

            input.read(lengthBytes);
            length = ByteUtils.bytes2int(lengthBytes);
            BatchProto.FileBatch filebatchProto = BatchProto.FileBatch.parseFrom(new LimitedInputStream(input, length));
            // 构造原始的model对象
            FileBatch fileBatch = new FileBatch();
            fileBatch.setIdentity(build(filebatchProto.getIdentity()));
            for (BatchProto.FileData fileDataProto : filebatchProto.getFilesList()) {
                FileData fileData = new FileData();
                fileData.setPairId(fileDataProto.getPairId());
                fileData.setTableId(fileDataProto.getTableId());
                fileData.setEventType(EventType.valuesOf(fileDataProto.getEventType()));
                fileData.setLastModifiedTime(fileDataProto.getLastModifiedTime());
                fileData.setNameSpace(fileDataProto.getNamespace());
                fileData.setPath(fileDataProto.getPath());
                fileData.setSize(fileDataProto.getSize());
                // 添加到filebatch中
                fileBatch.getFiles().add(fileData);
            }
            dbBatch.setFileBatch(fileBatch);
            return dbBatch;
        } catch (IOException e) {
            throw new PipeException("deserial_error", e);
        } finally {
            IOUtils.closeQuietly(reader);
        }
    }