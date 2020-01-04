@Override
    public DataResponse<Team> getTeam(ObjectId componentId,
                                              String teamId) {
        Component component = componentRepository.findOne(componentId);
        CollectorItem item = component.getCollectorItems()
                .get(CollectorType.AgileTool).get(0);

        // Get one scope by Id
        Team team = teamRepository.findByTeamId(teamId);

        Collector collector = collectorRepository
                .findOne(item.getCollectorId());

        return new DataResponse<>(team, collector.getLastExecuted());
    }