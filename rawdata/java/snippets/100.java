public List<Extension> getExtensions () {
		List<Extension> list = new ArrayList<Extension>();
		for (AddOn addOn : getAddOnCollection().getAddOns()) {
			list.addAll(getExtensions(addOn));
        }
		
		return list;
	}