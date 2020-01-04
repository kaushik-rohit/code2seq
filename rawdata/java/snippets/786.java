public static Context getContextByParamId(JSONObject params, String contextIdParamName)
			throws ApiException {
		int contextId = getIntParam(params, contextIdParamName);
		Context context = Model.getSingleton().getSession().getContext(contextId);
		if (context == null) {
			throw new ApiException(Type.CONTEXT_NOT_FOUND, contextIdParamName);
		}
		return context;
	}