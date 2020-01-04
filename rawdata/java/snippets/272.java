public final void writeNestedSerializerSnapshots(DataOutputView out) throws IOException {
		out.writeInt(MAGIC_NUMBER);
		out.writeInt(VERSION);

		out.writeInt(nestedSnapshots.length);
		for (TypeSerializerSnapshot<?> snap : nestedSnapshots) {
			TypeSerializerSnapshot.writeVersionedSnapshot(out, snap);
		}
	}