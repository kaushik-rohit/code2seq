public boolean isEventStream() {
		boolean isEventStream = false;
		if (!getResponseHeader().isEmpty()) {
			isEventStream = getResponseHeader().hasContentType("text/event-stream");
		} else {
			// response not available
			// is request for event-stream?
			String acceptHeader = getRequestHeader().getHeader("Accept");
			if (acceptHeader != null && acceptHeader.equals("text/event-stream")) {
				// request is for an SSE stream
				isEventStream = true;
			}
		}
		
		return isEventStream;
	}