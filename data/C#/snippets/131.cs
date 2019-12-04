public IEnumerable<Dynamo> Paged(MappingHolder Mappings, int PageSize, int Page, string[] OrderBy, string[] EmbeddedProperties)
        {
            if (OrderBy == null)
                OrderBy = new string[0];
            string OrderByClauseFinal = "";
            string Splitter = "";
            foreach (string OrderByClause in OrderBy)
            {
                var SplitValues = OrderByClause.Split(' ');
                if (SplitValues.Length > 0)
                {
                    if (Properties.Where(x => x is IReference || x is IID).Any(x => string.Equals(x.Name, SplitValues[0], StringComparison.InvariantCulture)))
                    {
                        OrderByClauseFinal += Splitter + SplitValues[0];
                        if (SplitValues.Length > 1)
                        {
                            SplitValues[1] = SplitValues[1].Equals("DESC", StringComparison.InvariantCultureIgnoreCase) ? "DESC" : "ASC";
                            OrderByClauseFinal += " " + SplitValues[1];
                        }
                        Splitter = ",";
                    }
                }
            }
            var Objects = PagedFunc(PageSize, Page, OrderByClauseFinal);
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