public virtual PagingToolbar.Builder RefreshText(string refreshText)
            {
                this.ToComponent().RefreshText = refreshText;
                return this as PagingToolbar.Builder;
            }