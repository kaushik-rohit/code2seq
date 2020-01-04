public override void AddParam(DbCommand cmd, object value)
        {
            var p = cmd.CreateParameter();
            p.ParameterName = $"@{cmd.Parameters.Count}";
            if (value == null)
            {
                p.Value = DBNull.Value;
            }
            else
            {
                if (value is Guid)
                {
                    p.Value = value.ToString();
                    p.DbType = DbType.String;
                    p.Size = 36;
                }
                else if (value is ExpandoObject)
                {
                    var d = (IDictionary<string, object>)value;
                    p.Value = d.Values.FirstOrDefault();
                }
                else
                {
                    p.Value = value;
                }
                var valueAsString = value as string;
                if (valueAsString != null)
                {
                    p.Size = valueAsString.Length > 4000 ? -1 : 4000;
                }
            }
            cmd.Parameters.Add(p);
        }