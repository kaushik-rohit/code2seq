public IEnumerable<int> ValidIndexies()
        {
            var length = Indexing.Indexes.Length;
            for(var i = 0; i < length; i++)
            {
                var stop = Indexing.Indexes[i].Stop;
                for(var j = Indexing.Indexes[i].Start; j <= stop; j++)
                {
                    yield return j;
                }
            }
        }