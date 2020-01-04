public String [] getParamNames() {
		Vector<String> v = new Vector<>();
		// Get the params names from the query
		SortedSet<String> pns = this.getParamNameSet(HtmlParameter.Type.url);
		Iterator<String> iterator = pns.iterator();
		while (iterator.hasNext()) {
			String name = iterator.next();
			if (name != null) {
				v.add(name);
			}
		}
		if (getRequestHeader().getMethod().equalsIgnoreCase(HttpRequestHeader.POST)) {
			// Get the param names from the POST
			pns = this.getParamNameSet(HtmlParameter.Type.form);
		    iterator = pns.iterator();
		    while (iterator.hasNext()) {
				String name = iterator.next();
		        if (name != null) {
		        	v.add(name);
		        }
				
			}
		}
		String [] a = new String [v.size()];
		v.toArray(a);
		return a;
	}