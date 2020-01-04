public virtual PagingToolbar.Builder PageSize(int pageSize)
            {
                this.ToComponent().PageSize = pageSize;
                return this as PagingToolbar.Builder;
            }