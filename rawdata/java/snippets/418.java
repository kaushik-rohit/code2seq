private void updatePage() {
		// retrieve page
		final int retrievalPage = page == LAST_PAGE ? pageCount : page;
		final List<Row> rows;
		try {
			rows = client.getExecutor().retrieveResultPage(resultDescriptor.getResultId(), retrievalPage);
		} catch (SqlExecutionException e) {
			close(e);
			return;
		}

		// convert page
		final List<String[]> stringRows = rows
				.stream()
				.map(CliUtils::rowToString)
				.collect(Collectors.toList());

		// update results
		if (previousResultsPage == retrievalPage) {
			// only use the previous results if the current page number has not changed
			// this allows for updated results when the key space remains constant
			previousResults = results;
		} else {
			previousResults = null;
			previousResultsPage = retrievalPage;
		}

		results = stringRows;

		// check if selected row is still valid
		if (selectedRow != NO_ROW_SELECTED) {
			if (selectedRow >= results.size()) {
				selectedRow = NO_ROW_SELECTED;
			}
		}

		// reset view
		resetAllParts();
	}