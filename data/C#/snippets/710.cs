public virtual PagingToolbar.Builder BeforePageText(string beforePageText)
            {
                this.ToComponent().BeforePageText = beforePageText;
                return this as PagingToolbar.Builder;
            }