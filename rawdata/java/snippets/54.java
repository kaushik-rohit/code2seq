@Override
    public void accumulateChunk(NDArrayMessageChunk chunk) {
        String id = chunk.getId();
        if (!chunks.containsKey(id)) {
            List<NDArrayMessageChunk> list = new ArrayList<>();
            list.add(chunk);
            chunks.put(id, list);
        } else {
            List<NDArrayMessageChunk> chunkList = chunks.get(id);
            chunkList.add(chunk);
        }

        log.debug("Accumulating chunk for id " + chunk.getId());


    }