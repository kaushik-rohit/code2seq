static FileSystemKind getKindForScheme(String scheme) {
		scheme = scheme.toLowerCase(Locale.US);

		if (scheme.startsWith("s3") || scheme.startsWith("emr") || scheme.startsWith("oss")) {
			// the Amazon S3 storage or Aliyun OSS storage
			return FileSystemKind.OBJECT_STORE;
		}
		else if (scheme.startsWith("http") || scheme.startsWith("ftp")) {
			// file servers instead of file systems
			// they might actually be consistent, but we have no hard guarantees
			// currently to rely on that
			return FileSystemKind.OBJECT_STORE;
		}
		else {
			// the remainder should include hdfs, kosmos, ceph, ...
			// this also includes federated HDFS (viewfs).
			return FileSystemKind.FILE_SYSTEM;
		}
	}