public MurmurHash hash(int input) {
		count++;

		input *= 0xcc9e2d51;
		input = Integer.rotateLeft(input, 15);
		input *= 0x1b873593;

		hash ^= input;
		hash = Integer.rotateLeft(hash, 13);
		hash = hash * 5 + 0xe6546b64;

		return this;
	}