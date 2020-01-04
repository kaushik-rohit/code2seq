public void SaveHTMLContent(string NavImagepath, string HTMLBodyText, int Bannerid, int UserModuleId, int ImageID, int PortalID, string CultureCode)
        {
            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                objp.SaveHTMLContent(NavImagepath, HTMLBodyText, Bannerid, UserModuleId, ImageID, PortalID, CultureCode);
            }
            catch (Exception e)
            {
                throw e;
            }
        }