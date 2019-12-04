protected static void PseudoClass<TOwner, TProperty>(
            AvaloniaProperty<TProperty> property,
            Func<TProperty, bool> selector,
            string className)
                where TOwner : class, IStyledElement
        {
            Contract.Requires<ArgumentNullException>(property != null);
            Contract.Requires<ArgumentNullException>(selector != null);
            Contract.Requires<ArgumentNullException>(className != null);

            if (string.IsNullOrWhiteSpace(className))
            {
                throw new ArgumentException("Cannot supply an empty className.");
            }

            property.Changed.Merge(property.Initialized)
                .Where(e => e.Sender is TOwner)
                .Subscribe(e =>
                {
                    if (selector((TProperty)e.NewValue))
                    {
                        ((StyledElement)e.Sender).PseudoClasses.Add(className);
                    }
                    else
                    {
                        ((StyledElement)e.Sender).PseudoClasses.Remove(className);
                    }
                });
        }