public static Set<String> parseUniqueEmails(final String emailList,
      final String splitRegex) {
    final Set<String> uniqueEmails = new HashSet<>();

    if (emailList == null) {
      return uniqueEmails;
    }

    final String[] emails = emailList.trim().split(splitRegex);
    for (final String email : emails) {
      if (!email.isEmpty()) {
        uniqueEmails.add(email);
      }
    }

    return uniqueEmails;
  }