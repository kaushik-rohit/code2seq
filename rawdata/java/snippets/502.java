@Override
  public OperationHandle getFunctions(SessionHandle sessionHandle,
      String catalogName, String schemaName, String functionName) throws HiveSQLException {
    try {
      TGetFunctionsReq req = new TGetFunctionsReq(sessionHandle.toTSessionHandle(), functionName);
      req.setCatalogName(catalogName);
      req.setSchemaName(schemaName);
      TGetFunctionsResp resp = cliService.GetFunctions(req);
      checkStatus(resp.getStatus());
      TProtocolVersion protocol = sessionHandle.getProtocolVersion();
      return new OperationHandle(resp.getOperationHandle(), protocol);
    } catch (HiveSQLException e) {
      throw e;
    } catch (Exception e) {
      throw new HiveSQLException(e);
    }
  }