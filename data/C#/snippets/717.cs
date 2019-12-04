public virtual PagingToolbar.Builder HideRefresh(bool hideRefresh)
            {
                this.ToComponent().HideRefresh = hideRefresh;
                return this as PagingToolbar.Builder;
            }