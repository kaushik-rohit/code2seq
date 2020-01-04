void add(long value) {
		if (value >= 0) {
			if (count > 0) {
				min =  Math.min(min, value);
				max = Math.max(max, value);
			} else {
				min = value;
				max = value;
			}

			count++;
			sum += value;
		}
	}