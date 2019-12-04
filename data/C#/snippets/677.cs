public int WriteRecord
            (
                [NotNull] MarcRecord record
            )
        {
            Code.NotNull(record, "record");

            int result = _mfn;

            record.Mfn = _mfn;
            record.Version = 1;
            record.Status = RecordStatus.Last;
            long position = _mstPosition;
            MstRecord64 mstRecord = MstRecord64.EncodeRecord(record);
            mstRecord.Prepare();
            mstRecord.Write(_mst);

            _xrf.WriteInt64Network(position);
            _xrf.WriteInt32Network((int)RecordStatus.NonActualized);
            _xrfPosition += XrfRecord64.RecordSize;

            _mfn++;
            _needUpdate = true;

            return result;
        }