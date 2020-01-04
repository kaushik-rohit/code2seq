protected void initialize() {

        this.addActionListener(new java.awt.event.ActionListener() { 

        	@Override
        	public void actionPerformed(java.awt.event.ActionEvent e) {
        		log.debug("actionPerformed " + lastInvoker.name() + " " + e.getActionCommand());

        	    try {
        	    	if (multiSelect) {
            	    	performActions(getSelectedHistoryReferences());
        	    		
        	    	} else {
	            	    HistoryReference ref = getSelectedHistoryReference();
		        		if (ref != null) {
		            	    try {
		            	    	performAction(ref);
		                    } catch (Exception e1) {
		    					log.error(e1.getMessage(), e1);
		                    }
		        		} else {
		        			log.error("PopupMenuHistoryReference invoker " + lastInvoker + " failed to get history ref");
		        		}
        	    	}
				} catch (Exception e2) {
					log.error(e2.getMessage(), e2);
				}
        	}
        });
	}