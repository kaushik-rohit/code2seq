public void SetVerticalOffset(double offset)
        {
            if (disableScrollOffsetSync)
            {
                return;
            }

            try
            {
                disableScrollOffsetSync = true;

                ContentOffsetY = offset / ContentScale;
            }
            finally
            {
                disableScrollOffsetSync = false;
            }
        }