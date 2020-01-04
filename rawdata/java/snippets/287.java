public List <AddOn> getNewAddOns(AddOnCollection aoc) {
        List<AddOn> newAddOns = new ArrayList<>();

    	for (AddOn ao : aoc.getAddOns()) {
    		boolean isNew = true;
        	for (AddOn addOn : addOns) {
        		try {
					if (ao.isSameAddOn(addOn)) {
						isNew = false;
						break;
					}
				} catch (Exception e) {
		    		logger.error(e.getMessage(), e);
				}
        	}
    		if (isNew) {
				newAddOns.add(ao);
    		}
        }
    	return newAddOns;
    }