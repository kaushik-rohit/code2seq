public virtual PagingToolbar.Builder DisplayInfo(bool displayInfo)
            {
                this.ToComponent().DisplayInfo = displayInfo;
                return this as PagingToolbar.Builder;
            }