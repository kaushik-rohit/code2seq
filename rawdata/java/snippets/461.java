@Override
	public int compareTo(ValueArray<CharValue> o) {
		CharValueArray other = (CharValueArray) o;

		int min = Math.min(position, other.position);
		for (int i = 0; i < min; i++) {
			int cmp = Character.compare(data[i], other.data[i]);

			if (cmp != 0) {
				return cmp;
			}
		}

		return Integer.compare(position, other.position);
	}