public ItemRestrictions Convert(ICollection<string> value, object state)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            var result = default(ItemRestrictions);
            foreach (var s in value)
            {
                result |= this.itemRestrictionConverter.Convert(s, state);
            }

            return result;
        }