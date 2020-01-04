@Restricted(DoNotUse.class) // WebOnly
    public HttpResponse doRestartStatus() throws IOException {
        JSONObject response = new JSONObject();
        Jenkins jenkins = Jenkins.get();
        response.put("restartRequired", jenkins.getUpdateCenter().isRestartRequiredForCompletion());
        response.put("restartSupported", jenkins.getLifecycle().canRestart());
        return HttpResponses.okJSON(response);
    }