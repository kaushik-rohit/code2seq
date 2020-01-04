private static Audit getOSSAudit(JSONArray jsonArray, JSONArray global) {

        LOGGER.info("NFRR Audit Collector auditing LIBRARY_POLICY");
        Audit audit = new Audit();
        audit.setType(AuditType.LIBRARY_POLICY);

        Audit basicAudit;
        if ((basicAudit = doBasicAuditCheck(jsonArray, global, AuditType.LIBRARY_POLICY)) != null) {
            return basicAudit;
        }
        audit.setAuditStatus(AuditStatus.OK);
        audit.setDataStatus(DataStatus.OK);
        for (Object o : jsonArray) {
            JSONArray auditJO = (JSONArray) ((JSONObject) o).get(STR_AUDITSTATUSES);
            Optional<Object> lpOptObj = Optional.ofNullable(((JSONObject) o).get(STR_LIBRARYPOLICYRESULT));
            lpOptObj.ifPresent(lpObj -> audit.getUrl().add(((JSONObject) lpOptObj.get()).get(STR_REPORTURL).toString()));
            auditJO.stream().map(aj -> audit.getAuditStatusCodes().add((String) aj));
            boolean ok = false;
            for (Object s : auditJO) {
                String status = (String) s;
                audit.getAuditStatusCodes().add(status);
                if (LibraryPolicyAuditStatus.LIBRARY_POLICY_AUDIT_OK.name().equalsIgnoreCase(status)) {
                    ok = true;
                    break;
                }
                if (LibraryPolicyAuditStatus.LIBRARY_POLICY_AUDIT_MISSING.name().equalsIgnoreCase(status)) {
                    audit.setAuditStatus(AuditStatus.NA);
                    audit.setDataStatus(DataStatus.NO_DATA);
                    return audit;
                }
            }
            if (!ok) {
                audit.setAuditStatus(AuditStatus.FAIL);
                return audit;
            }
        }
        return audit;
    }