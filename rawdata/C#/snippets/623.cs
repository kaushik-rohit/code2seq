public void DeleteHTMLContentByID(int ImageId)
        {
            try
            {
                SageBannerProvider objP = new SageBannerProvider();
                objP.DeleteHTMLContentByID(ImageId);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }