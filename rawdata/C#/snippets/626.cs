public SageBannerSettingInfo GetSageBannerSettingList(int PortalID, int UserModuleID, string CultureCode)
        {
            try
            {
                SageBannerSettingInfo objSageBannerSettingInfo = new SageBannerSettingInfo();
                if (HttpRuntime.Cache["BannerSetting_" + CultureCode + "_" + UserModuleID.ToString()] != null)
                {
                    objSageBannerSettingInfo = HttpRuntime.Cache["BannerSetting_" + CultureCode + "_" + UserModuleID.ToString()] as SageBannerSettingInfo;
                }
                else
                {
                    SageBannerProvider objp = new SageBannerProvider();
                    objSageBannerSettingInfo = objp.GetSageBannerSettingList(PortalID, UserModuleID, CultureCode);
                    HttpRuntime.Cache["BannerSetting_" + CultureCode + "_" + UserModuleID.ToString()] = objSageBannerSettingInfo;
                }
                return objSageBannerSettingInfo;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }