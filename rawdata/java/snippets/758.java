@Deprecated
    public void doLogRss( StaplerRequest req, StaplerResponse rsp ) throws IOException, ServletException {
        String qs = req.getQueryString();
        rsp.sendRedirect2("./log/rss"+(qs==null?"":'?'+qs));
    }