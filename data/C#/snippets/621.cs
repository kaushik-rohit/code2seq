public void DeleteBannerContentByID(int ImageId)
        {
            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                objp.DeleteBannerContentByID(ImageId);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }