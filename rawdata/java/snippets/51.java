@Override
    protected boolean isButtonEnabledForHistoryReference(HistoryReference historyReference) {
        final SiteNode siteNode = getSiteNode(historyReference);
        if (siteNode != null && !isButtonEnabledForSiteNode(siteNode)) {
            return false;
        }
        return true;
    }