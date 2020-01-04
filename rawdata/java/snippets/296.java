public static void listen(ClipboardListener listener, boolean sync) {
		listen(ClipboardMonitor.DEFAULT_TRY_COUNT, ClipboardMonitor.DEFAULT_DELAY, listener, sync);
	}