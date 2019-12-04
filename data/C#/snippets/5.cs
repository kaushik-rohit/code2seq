public async void InitializeAsync([NotNull] IQueryResult result)
        {
            var table = new DataTable();
            var types = new Dictionary<string, HashSet<Type>>();

            var rowCollection = await new InMemoryPolicy().MaterializeAsync(result.Rows.Select(row =>
            {
                foreach (var column in row.ColumnNames)
                {
                    var value = row[column];

                    if (value != null)
                    {
                        var typeSet = types.TryGetValue(column, out var hashSet) ? hashSet : (hashSet = types[column] = new HashSet<Type>());
                        typeSet.Add(value.GetType());
                    }
                }

                return row;
            }));

            var first = await rowCollection.FirstOrDefaultAsync();

            if (first != null)
            {
                var columns = first.ColumnNames
                                .Select(c => new DataColumn
                                {
                                    ColumnName = c,
                                    DataType = types.TryGetValue(c, out var hashSet) && hashSet.Count == 1 ? hashSet.First() : typeof(object)
                                })
                                .ToArray();

                table.Columns.AddRange(columns);

                await rowCollection.ForEachAsync(row =>
                {
                    var tableRow = table.NewRow();

                    foreach (var column in row.ColumnNames)
                    {
                        var value = row[column];

                        if (value != null)
                        {
                            tableRow[column] = value;
                        }
                    }

                    table.Rows.Add(tableRow);
                });
            }

            this.Rows = table;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Rows)));
        }