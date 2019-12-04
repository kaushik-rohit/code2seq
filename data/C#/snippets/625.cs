public string GetFileName(int ImageId)
        {

            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                return objp.GetFileName(ImageId);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }