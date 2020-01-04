private boolean notifyPersistentConnectionListener(HttpMessage httpMessage, Socket inSocket, ZapGetMethod method) {
		boolean keepSocketOpen = false;
		PersistentConnectionListener listener = null;
		List<PersistentConnectionListener> listenerList = parentServer.getPersistentConnectionListenerList();
		for (int i=0; i<listenerList.size(); i++) {
			listener = listenerList.get(i);
			try {
			    if (listener.onHandshakeResponse(httpMessage, inSocket, method)) {
			    	// inform as long as one listener wishes to overtake the connection
			    	keepSocketOpen = true;
			    	break;
			    }
			} catch (Exception e) {
				log.error("An error occurred while notifying listener:", e);
			}
		}
		return keepSocketOpen;
	}