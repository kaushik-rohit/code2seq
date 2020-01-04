public static int getJavaCompilerVersion() {
		int cv = compilerVersion.get();
		if (cv != -1) return cv;
		
		/* Main algorithm: Use JavaCompiler's intended method to do this */ {
			Matcher m = VERSION_PARSER.matcher(JavaCompiler.version());
			if (m.matches()) {
				int major = Integer.parseInt(m.group(1));
				if (major == 1) {
					int minor = Integer.parseInt(m.group(2));
					return setVersion(minor);
				}
				if (major >= 9) return setVersion(major);
			}
		}
		
		/* Fallback algorithm one: Check Source's values. Lets hope oracle never releases a javac that recognizes future versions for -source */ {
			String name = Source.values()[Source.values().length - 1].name();
			Matcher m = SOURCE_PARSER.matcher(name);
			if (m.matches()) {
				int major = Integer.parseInt(m.group(1));
				if (major == 1) {
					int minor = Integer.parseInt(m.group(2));
					return setVersion(minor);
				}
				if (major >= 9) return setVersion(major);
			}
		}
		return setVersion(6);
	}