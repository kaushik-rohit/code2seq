@Override
  public void recordIdentityLinkCreated(IdentityLinkEntity identityLink) {
    // It makes no sense storing historic counterpart for an identity-link
    // that is related
    // to a process-definition only as this is never kept in history
    if (isHistoryLevelAtLeast(HistoryLevel.AUDIT) && (identityLink.getProcessInstanceId() != null || identityLink.getTaskId() != null)) {
      HistoricIdentityLinkEntity historicIdentityLinkEntity = getHistoricIdentityLinkEntityManager().create();
      historicIdentityLinkEntity.setId(identityLink.getId());
      historicIdentityLinkEntity.setGroupId(identityLink.getGroupId());
      historicIdentityLinkEntity.setProcessInstanceId(identityLink.getProcessInstanceId());
      historicIdentityLinkEntity.setTaskId(identityLink.getTaskId());
      historicIdentityLinkEntity.setType(identityLink.getType());
      historicIdentityLinkEntity.setUserId(identityLink.getUserId());
      getHistoricIdentityLinkEntityManager().insert(historicIdentityLinkEntity, false);
    }
  }