public Dynamo Any(string ID, MappingHolder Mappings, params string[] EmbeddedProperties)
        {
            if (string.IsNullOrEmpty(ID))
                throw new ArgumentNullException(nameof(ID));
            var Object = AnyFunc(ID);
            if (!CanGetFunc(Object))
                return null;
            var TempItem = new Dynamo(Object);
            Dynamo ReturnValue = TempItem.SubSet(Properties.Where(x => x is IReference || x is IID)
                                                           .Select(x => x.Name)
                                                           .ToArray());
            string AbsoluteUri = HttpContext.Current != null ? HttpContext.Current.Request.Url.AbsoluteUri.Left(HttpContext.Current.Request.Url.AbsoluteUri.IndexOf('?')) : "";
            if (!AbsoluteUri.EndsWith("/", StringComparison.Ordinal))
                AbsoluteUri += "/";
            foreach (IAPIProperty Property in Properties.Where(x => x is IMap))
            {
                ReturnValue[Property.Name] = EmbeddedProperties.Contains(Property.Name) ?
                                                (object)Property.GetValue(Mappings, TempItem) :
                                                (object)(AbsoluteUri + Property.Name);
            }
            return ReturnValue;
        }