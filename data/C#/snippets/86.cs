public IEnumerable<Dynamo> All(MappingHolder Mappings, params string[] EmbeddedProperties)
        {
            var Objects = AllFunc();
            if (Objects == null)
                Objects = new List<ClassType>();
            var ReturnValue = new List<Dynamo>();
            foreach (ClassType Object in Objects)
            {
                if (CanGetFunc(Object))
                {
                    var TempItem = new Dynamo(Object);
                    Dynamo ReturnItem = TempItem.SubSet(Properties.Where(x => x is IReference || x is IID)
                                                                   .Select(x => x.Name)
                                                                   .ToArray());
                    string AbsoluteUri = HttpContext.Current != null ? HttpContext.Current.Request.Url.AbsoluteUri.Left(HttpContext.Current.Request.Url.AbsoluteUri.IndexOf('?')) : "";
                    AbsoluteUri = AbsoluteUri.Check("");
                    if (!AbsoluteUri.EndsWith("/", StringComparison.Ordinal))
                        AbsoluteUri += "/";
                    AbsoluteUri += Properties.FirstOrDefault(x => x is IID).GetValue(Mappings, Object).ToString() + "/";
                    foreach (IAPIProperty Property in Properties.Where(x => x is IMap))
                    {
                        ReturnItem[Property.Name] = EmbeddedProperties.Contains(Property.Name) ?
                                                        (object)Property.GetValue(Mappings, TempItem) :
                                                        (object)(AbsoluteUri + Property.Name);
                    }
                    ReturnValue.Add(ReturnItem);
                }
            }
            return ReturnValue;
        }