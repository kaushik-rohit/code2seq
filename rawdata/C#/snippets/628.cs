public List<SageBannerInfo> GetBannerImages(int BannerID, int UserModuleID, int PortalID, string CultureCode)
        {
            try
            {
                List<SageBannerInfo> objSageBannerLst = new List<SageBannerInfo>();
                if (HttpRuntime.Cache["BannerImages_" + CultureCode + "_" + UserModuleID.ToString()] != null)
                {
                    objSageBannerLst = HttpRuntime.Cache["BannerImages_" + CultureCode + "_" + UserModuleID.ToString()] as List<SageBannerInfo>;
                }
                else
                {
                    SageBannerProvider objp = new SageBannerProvider();
                    objSageBannerLst = objp.GetBannerImages(BannerID, UserModuleID, PortalID, CultureCode);
                    HttpRuntime.Cache["BannerImages_" + CultureCode + "_" + UserModuleID.ToString()] = objSageBannerLst;
                }
                return objSageBannerLst;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }