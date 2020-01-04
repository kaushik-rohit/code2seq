private void highlightAll() {
		HighlighterManager highlighter = HighlighterManager.getInstance();
		
		LinkedList<HighlightSearchEntry> highlights = highlighter.getHighlights();
		for (HighlightSearchEntry entry: highlights) {
			highlightEntryParser(entry);
		}
	}