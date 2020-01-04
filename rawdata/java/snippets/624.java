public static Protos.Resource scalar(String name, String role, double value) {
		checkNotNull(name);
		checkNotNull(role);
		checkNotNull(value);
		return Protos.Resource.newBuilder()
			.setName(name)
			.setType(Protos.Value.Type.SCALAR)
			.setScalar(Protos.Value.Scalar.newBuilder().setValue(value))
			.setRole(role)
			.build();
	}