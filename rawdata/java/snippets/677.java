@Override
	public void close(boolean compact, boolean cleanup) {
		logger.debug("close");
		super.close(compact, cleanup);
	    if (this.getDatabaseServer() == null) {
	    	return;
	    }
	    
	    try {
	        // shutdown
	    	((HsqldbDatabaseServer)this.getDatabaseServer()).shutdown(compact);
        } catch (Exception e) {
            logger.error(e.getMessage(), e);
        }
	}