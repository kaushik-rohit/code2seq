public List<SageBannerInfo> LoadBannerListOnGrid(int PortalID, int UserModuleID, string CultureCode)
        {
            SageBannerProvider obj = new SageBannerProvider();
            return obj.LoadBannerListOnGrid(PortalID, UserModuleID, CultureCode);
        }