public SageBannerInfo GetHTMLContentForEditByID(int ImageID)
        {
            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                return objp.GetHTMLContentForEditByID(ImageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }