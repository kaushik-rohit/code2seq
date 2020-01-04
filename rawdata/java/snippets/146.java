public static String getPinYin(String chinese) {
		final StrBuilder result = StrUtil.strBuilder();
		String strTemp = null;
		int len = chinese.length();
		for (int j = 0; j < len; j++) {
			strTemp = chinese.substring(j, j + 1);
			int ascii = getChsAscii(strTemp);
			if (ascii > 0) {
				//非汉字
				result.append((char)ascii);
			} else {
				for (int i = pinyinValue.length - 1; i >= 0; i--) {
					if (pinyinValue[i] <= ascii) {
						result.append(pinyinStr[i]);
						break;
					}
				}
			}
		}
		return result.toString();
	}