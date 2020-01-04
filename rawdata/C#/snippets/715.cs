public virtual PagingToolbar.Builder PrevText(string prevText)
            {
                this.ToComponent().PrevText = prevText;
                return this as PagingToolbar.Builder;
            }