public void DeleteBannerAndItsContentByBannerID(int BannerID)
        {
            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                objp.DeleteBannerAndItsContentByBannerID(BannerID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }