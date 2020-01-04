public static Map<String, List<Object>> retrieveAttributesFromAttributeRepository(final IPersonAttributeDao attributeRepository,
                                                                                      final String principalId,
                                                                                      final Set<String> activeAttributeRepositoryIdentifiers) {
        var filter = IPersonAttributeDaoFilter.alwaysChoose();
        if (activeAttributeRepositoryIdentifiers != null && !activeAttributeRepositoryIdentifiers.isEmpty()) {
            val repoIdsArray = activeAttributeRepositoryIdentifiers.toArray(ArrayUtils.EMPTY_STRING_ARRAY);
            filter = dao -> Arrays.stream(dao.getId())
                .anyMatch(daoId -> daoId.equalsIgnoreCase(IPersonAttributeDao.WILDCARD)
                    || StringUtils.equalsAnyIgnoreCase(daoId, repoIdsArray)
                    || StringUtils.equalsAnyIgnoreCase(IPersonAttributeDao.WILDCARD, repoIdsArray));
        }
        val attrs = attributeRepository.getPerson(principalId, filter);
        if (attrs == null) {
            return new HashMap<>(0);
        }
        return attrs.getAttributes();

    }