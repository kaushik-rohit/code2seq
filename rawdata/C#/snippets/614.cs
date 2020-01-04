public List<SageBannerInfo> LoadBannerOnDropDown(int UserModuleID, int PortalID, string CultureCode)
        {
            try
            {
                SageBannerProvider obj = new SageBannerProvider();
                return obj.LoadBannerOnDropDown(UserModuleID, PortalID, CultureCode);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }