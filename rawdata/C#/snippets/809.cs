public void Add(T item)
        {
            var y = item - _compensation;
            var t = Sum + y;
            _compensation = (t - Sum) - y;
            Sum = t;
        }