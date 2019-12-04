public void UpdateControlRecord()
        {
            long nextPosition = _mst.Length;
            _mst.Seek(0, SeekOrigin.Begin);
            MstControlRecord64 control = MstControlRecord64.Read(_mst);
            control.Blocked = 0;
            control.NextMfn = _mfn;
            control.NextPosition = nextPosition;

            _mst.Seek(0, SeekOrigin.Begin);
            control.Write(_mst);
        }