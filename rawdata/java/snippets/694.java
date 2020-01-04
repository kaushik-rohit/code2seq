private static void genRanks(int noDocs, String path) {

		Random rand = new Random(Calendar.getInstance().getTimeInMillis());

		try (BufferedWriter fw = new BufferedWriter(new FileWriter(path))) {
			for (int i = 0; i < noDocs; i++) {
				// Rank
				StringBuilder rank = new StringBuilder(rand.nextInt(100) + "|");
				// URL
				rank.append("url_" + i + "|");
				// Average duration
				rank.append(rand.nextInt(10) + rand.nextInt(50) + "|\n");

				fw.write(rank.toString());
			}
		} catch (IOException e) {
			e.printStackTrace();
		}
	}