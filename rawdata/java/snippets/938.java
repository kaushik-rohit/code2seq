@RequirePOST
    public synchronized void doConfigExecutorsSubmit( StaplerRequest req, StaplerResponse rsp ) throws IOException, ServletException, FormException {
        checkPermission(ADMINISTER);

        BulkChange bc = new BulkChange(this);
        try {
            JSONObject json = req.getSubmittedForm();

            ExtensionList.lookupSingleton(MasterBuildConfiguration.class).configure(req,json);

            getNodeProperties().rebuild(req, json.optJSONObject("nodeProperties"), NodeProperty.all());
        } finally {
            bc.commit();
        }

        updateComputerList();

        rsp.sendRedirect(req.getContextPath()+'/'+toComputer().getUrl());  // back to the computer page
    }