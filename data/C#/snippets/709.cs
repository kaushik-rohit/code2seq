public virtual PagingToolbar.Builder AfterPageText(string afterPageText)
            {
                this.ToComponent().AfterPageText = afterPageText;
                return this as PagingToolbar.Builder;
            }