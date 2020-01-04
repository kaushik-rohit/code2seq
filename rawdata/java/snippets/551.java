public static <T extends CharSequence> T validateCitizenIdNumber(T value, String errorMsg) throws ValidateException {
		if (false == isCitizenId(value)) {
			throw new ValidateException(errorMsg);
		}
		return value;
	}