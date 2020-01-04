@SuppressWarnings("PMD.NPathComplexity")
    protected Feature getFeature(JSONObject issue, Team board) {
        Feature feature = new Feature();
        feature.setsId(getString(issue, "id"));
        feature.setsNumber(getString(issue, "key"));

        JSONObject fields = (JSONObject) issue.get("fields");

        JSONObject epic = (JSONObject) fields.get("epic");
        String epicId = getString(fields, featureSettings.getJiraEpicIdFieldName());
        feature.setsEpicID(epic != null ? getString(epic, "id") : epicId);

        JSONObject issueType = (JSONObject) fields.get("issuetype");
        if (issueType != null) {
            feature.setsTypeId(getString(issueType, "id"));
            feature.setsTypeName(getString(issueType, "name"));
        }

        JSONObject status = (JSONObject) fields.get("status");
        String sStatus = getStatus(status);
        feature.setsState(sStatus);
        feature.setsStatus(feature.getsState());

        String summary = getString(fields, "summary");
        feature.setsName(summary);

        feature.setsUrl(featureSettings.getJiraBaseUrl() + (featureSettings.getJiraBaseUrl().endsWith("/") ? "" : "/") + "browse/" + feature.getsNumber());

        long aggEstimate = getLong(fields, "aggregatetimeoriginalestimate");
        Long estimate = getLong(fields, "timeoriginalestimate");

        int originalEstimate = 0;
        // Tasks use timetracking, stories use aggregatetimeoriginalestimate and aggregatetimeestimate
        if (estimate != 0) {
            originalEstimate = estimate.intValue();
        } else if (aggEstimate != 0) {
            // this value is in seconds
            originalEstimate = Math.round((float) aggEstimate / 3600);
        }

        feature.setsEstimateTime(originalEstimate);

        String storyPoints = getString(fields, featureSettings.getJiraStoryPointsFieldName());

        feature.setsEstimate(storyPoints);

        feature.setChangeDate(getString(fields, "updated"));
        feature.setIsDeleted("False");

        JSONObject project = (JSONObject) fields.get("project");
        feature.setsProjectID(project != null ? getString(project, "id") : "");
        feature.setsProjectName(project != null ? getString(project, "name") : "");
        // sProjectBeginDate - does not exist in Jira
        feature.setsProjectBeginDate("");
        // sProjectEndDate - does not exist in Jira
        feature.setsProjectEndDate("");
        // sProjectChangeDate - does not exist for this asset level in Jira
        feature.setsProjectChangeDate("");
        // sProjectState - does not exist in Jira
        feature.setsProjectState("");
        // sProjectIsDeleted - does not exist in Jira
        feature.setsProjectIsDeleted("False");
        // sProjectPath - does not exist in Jira
        feature.setsProjectPath("");

        if(board != null){
            feature.setsTeamID(board.getTeamId());
            feature.setsTeamName(board.getName());
        } else {
            JSONObject team = (JSONObject) fields.get(featureSettings.getJiraTeamFieldName());
            if (team != null) {
                feature.setsTeamID(getString(team, "id"));
                feature.setsTeamName(getString(team, "value"));
            }
        }
        // sTeamChangeDate - not able to retrieve at this asset level from Jira
        feature.setsTeamChangeDate("");
        // sTeamAssetState
        feature.setsTeamAssetState("");
        // sTeamIsDeleted
        feature.setsTeamIsDeleted("False");
        // sOwnersState - does not exist in Jira at this level
        feature.setsOwnersState(Collections.singletonList("Active"));
        // sOwnersChangeDate - does not exist in Jira
        feature.setsOwnersChangeDate(Collections.EMPTY_LIST);
        // sOwnersIsDeleted - does not exist in Jira
        feature.setsOwnersIsDeleted(Collections.EMPTY_LIST);
        // issueLinks
        JSONArray issueLinkArray = (JSONArray) fields.get("issuelinks");
        feature.setIssueLinks(getIssueLinks(issueLinkArray));

        Sprint sprint = getSprint(fields);
        if (sprint != null) {
            processSprintData(feature, sprint);
        }
        JSONObject assignee = (JSONObject) fields.get("assignee");
        processAssigneeData(feature, assignee);
        return feature;
    }