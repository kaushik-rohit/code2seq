private CanalDO modelToDo(Canal canal) {
        CanalDO canalDo = new CanalDO();
        try {
            canalDo.setId(canal.getId());
            canalDo.setName(canal.getName());
            canalDo.setStatus(canal.getStatus());
            canalDo.setDescription(canal.getDesc());
            canalDo.setParameters(canal.getCanalParameter());
            canalDo.setGmtCreate(canal.getGmtCreate());
            canalDo.setGmtModified(canal.getGmtModified());
        } catch (Exception e) {
            logger.error("ERROR ## change the canal Model to Do has an exception");
            throw new ManagerException(e);
        }
        return canalDo;
    }