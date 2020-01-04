public List<SageBannerInfo> LoadHTMLContentOnGrid(int BannerID, int UserModuleID, int PortalID, string CultureCode)
        {
            try
            {
                SageBannerProvider obj = new SageBannerProvider();
                return obj.LoadHTMLContentOnGrid(BannerID, UserModuleID, PortalID, CultureCode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }