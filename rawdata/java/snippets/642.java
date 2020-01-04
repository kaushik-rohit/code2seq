private ActiveScan getActiveScan(JSONObject params) throws ApiException {
		int id = getParam(params, PARAM_SCAN_ID, -1);

		GenericScanner2 activeScan = null;

		if (id == -1) {
			activeScan = controller.getLastScan();
		} else {
			activeScan = controller.getScan(id);
		}

		if (activeScan == null) {
			throw new ApiException(ApiException.Type.DOES_NOT_EXIST, PARAM_SCAN_ID);
		}

		return (ActiveScan)activeScan;
	}