protected void createHasServiceCheckDecisionState(final Flow flow) {
        createDecisionState(flow, CasWebflowConstants.STATE_ID_HAS_SERVICE_CHECK,
            "flowScope.service != null",
            CasWebflowConstants.STATE_ID_RENEW_REQUEST_CHECK,
            CasWebflowConstants.STATE_ID_VIEW_GENERIC_LOGIN_SUCCESS);
    }