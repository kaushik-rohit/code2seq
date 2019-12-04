public SageBannerInfo GetImageInformationByID(int ImageID)
        {
            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                return objp.GetImageInformationByID(ImageID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }