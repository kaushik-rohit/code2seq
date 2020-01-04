@SuppressWarnings("unchecked")
	@Override
	public int hash(T value) {
		int i = 0;
		try {
			int code = this.comparators[0].hash(value.getFieldNotNull(keyPositions[0]));
			for (i = 1; i < this.keyPositions.length; i++) {
				code *= HASH_SALT[i & 0x1F]; // salt code with (i % HASH_SALT.length)-th salt component
				code += this.comparators[i].hash(value.getFieldNotNull(keyPositions[i]));
			}
			return code;
		}
		catch (NullFieldException nfex) {
			throw new NullKeyFieldException(nfex);
		}
		catch (IndexOutOfBoundsException iobex) {
			throw new KeyFieldOutOfBoundsException(keyPositions[i]);
		}
	}