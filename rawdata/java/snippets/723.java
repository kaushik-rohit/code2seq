public static boolean validateBySecureKey(Map<String, String> resData, String secureKey, String encoding) {
		LogUtil.writeLog("验签处理开始");
		if (isEmpty(encoding)) {
			encoding = "UTF-8";
		}
		String signMethod = resData.get(SDKConstants.param_signMethod);
		if (SIGNMETHOD_SHA256.equals(signMethod)) {
			// 1.进行SHA256验证
			String stringSign = resData.get(SDKConstants.param_signature);
			LogUtil.writeLog("签名原文：["+stringSign+"]");
			// 将Map信息转换成key1=value1&key2=value2的形式
			String stringData = coverMap2String(resData);
			LogUtil.writeLog("待验签返回报文串：["+stringData+"]");
			String strBeforeSha256 = stringData
					+ SDKConstants.AMPERSAND
					+ SecureUtil.sha256X16Str(secureKey, encoding);
			String strAfterSha256 = SecureUtil.sha256X16Str(strBeforeSha256,
					encoding);
			return stringSign.equals(strAfterSha256);
		} else if (SIGNMETHOD_SM3.equals(signMethod)) {
			// 1.进行SM3验证
			String stringSign = resData.get(SDKConstants.param_signature);
			LogUtil.writeLog("签名原文：["+stringSign+"]");
			// 将Map信息转换成key1=value1&key2=value2的形式
			String stringData = coverMap2String(resData);
			LogUtil.writeLog("待验签返回报文串：["+stringData+"]");
			String strBeforeSM3 = stringData
					+ SDKConstants.AMPERSAND
					+ SecureUtil.sm3X16Str(secureKey, encoding);
			String strAfterSM3 = SecureUtil
					.sm3X16Str(strBeforeSM3, encoding);
			return stringSign.equals(strAfterSM3);
		}
		return false;
	}