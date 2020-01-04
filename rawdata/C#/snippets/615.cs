public List<SageBannerInfo> LoadBannerImagesOnGrid(int BannerID, int UserModuleID, int PortalID, string CultureCode)
        {
            try
            {
                SageBannerProvider obj = new SageBannerProvider();
                return obj.LoadBannerImagesOnGrid(BannerID, UserModuleID, PortalID, CultureCode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }