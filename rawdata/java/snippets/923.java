public static HandlerLibrary load(Messager messager, Trees trees) {
		HandlerLibrary library = new HandlerLibrary(messager);
		
		try {
			loadAnnotationHandlers(library, trees);
			loadVisitorHandlers(library, trees);
		} catch (IOException e) {
			System.err.println("Lombok isn't running due to misconfigured SPI files: " + e);
		}
		
		library.calculatePriorities();
		
		return library;
	}