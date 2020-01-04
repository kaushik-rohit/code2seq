public int compareTo(UUID val) {
		// The ordering is intentionally set up so that the UUIDs
		// can simply be numerically compared as two numbers
		return (this.mostSigBits < val.mostSigBits ? -1 : //
				(this.mostSigBits > val.mostSigBits ? 1 : //
						(this.leastSigBits < val.leastSigBits ? -1 : //
								(this.leastSigBits > val.leastSigBits ? 1 : //
										0))));
	}