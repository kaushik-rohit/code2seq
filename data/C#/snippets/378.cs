public int[] ValidIndexArray()
        {
            var ret = new int[Data.Length];
            var pos = 0;
            var length = Indexing.Indexes.Length;
            for(var i = 0; i < length; i++)
            {
                var stop = Indexing.Indexes[i].Stop;
                for(var j = Indexing.Indexes[i].Start; j <= stop; j++)
                {
                    ret[pos++] = j;
                }
            }
            return ret;
        }