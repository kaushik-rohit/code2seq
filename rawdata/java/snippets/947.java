public BinaryString trimRight(BinaryString trimStr) {
		ensureMaterialized();
		if (trimStr == null) {
			return null;
		}
		trimStr.ensureMaterialized();
		if (trimStr.isSpaceString()) {
			return trimRight();
		}
		if (inFirstSegment()) {
			int charIdx = 0;
			int byteIdx = 0;
			// each element in charLens is length of character in the source string
			int[] charLens = new int[sizeInBytes];
			// each element in charStartPos is start position of first byte in the source string
			int[] charStartPos = new int[sizeInBytes];
			while (byteIdx < sizeInBytes) {
				charStartPos[charIdx] = byteIdx;
				charLens[charIdx] = numBytesForFirstByte(getByteOneSegment(byteIdx));
				byteIdx += charLens[charIdx];
				charIdx++;
			}
			// searchIdx points to the first character which is not in trim string from the right
			// end.
			int searchIdx = sizeInBytes - 1;
			charIdx -= 1;
			while (charIdx >= 0) {
				BinaryString currentChar = copyBinaryStringInOneSeg(
					charStartPos[charIdx],
					charStartPos[charIdx] + charLens[charIdx] - 1);
				if (trimStr.contains(currentChar)) {
					searchIdx -= charLens[charIdx];
				} else {
					break;
				}
				charIdx--;
			}
			if (searchIdx < 0) {
				// empty string
				return EMPTY_UTF8;
			} else {
				return copyBinaryStringInOneSeg(0, searchIdx);
			}
		} else {
			return trimRightSlow(trimStr);
		}
	}