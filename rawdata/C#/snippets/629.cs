public void SortImageList(int ImageId, bool MoveUp)
        {
            try
            {
                SageBannerProvider objp = new SageBannerProvider();
                objp.SortImageList(ImageId, MoveUp);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }