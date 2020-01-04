public virtual PagingToolbar.Builder DisplayMsg(string displayMsg)
            {
                this.ToComponent().DisplayMsg = displayMsg;
                return this as PagingToolbar.Builder;
            }