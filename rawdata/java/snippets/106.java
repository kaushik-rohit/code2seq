@RequestMapping(value = "/dashboard/mydashboard/filter/count/{title}/{type}", method = GET, produces = APPLICATION_JSON_VALUE)
    public long myDashboardsFilterCount(@PathVariable String title, @PathVariable String type) {
        return dashboardService.getMyDashboardsByTitleCount(title, type);
    }