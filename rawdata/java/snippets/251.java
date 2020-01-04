public void setValue(CharSequence value, int offset, int len) {
		checkNotNull(value);
		if (offset < 0 || len < 0 || offset > value.length() - len) {
			throw new IndexOutOfBoundsException("offset: " + offset + " len: " + len + " value.len: " + len);
		}

		ensureSize(len);
		this.len = len;		
		for (int i = 0; i < len; i++) {
			this.value[i] = value.charAt(offset + i);
		}
		this.hashCode = 0;
	}