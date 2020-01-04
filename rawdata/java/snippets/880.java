public static String toStr(Number number) {
		if (null == number) {
			throw new NullPointerException("Number is null !");
		}

		if (false == ObjectUtil.isValidIfNumber(number)) {
			throw new IllegalArgumentException("Number is non-finite!");
		}

		// 去掉小数点儿后多余的0
		String string = number.toString();
		if (string.indexOf('.') > 0 && string.indexOf('e') < 0 && string.indexOf('E') < 0) {
			while (string.endsWith("0")) {
				string = string.substring(0, string.length() - 1);
			}
			if (string.endsWith(".")) {
				string = string.substring(0, string.length() - 1);
			}
		}
		return string;
	}