public override string ToString()
        {
            if (_isFrozen)
            {
                return _frozenStringRepresentation;
            }

            var parts = new List<string>();
            if (_collectionName.HasBeenSet)
            {
                parts.Add(string.Format("CollectionName={0}", _collectionName.Value));
            }
            if (_defaultDocumentType.HasBeenSet)
            {
                parts.Add(string.Format("DefaultDocumentType={0}", _defaultDocumentType.Value));
            }
            parts.Add(string.Format("AssignIdOnInsert={0}", _assignIdOnInsert));
            parts.Add(string.Format("GuidRepresentation={0}", _guidRepresentation));
            if (_readEncoding.HasBeenSet)
            {
                parts.Add(string.Format("ReadEncoding={0}", (_readEncoding.Value == null) ? "null" : "UTF8Encoding"));
            }
            parts.Add(string.Format("ReadPreference={0}", _readPreference));
            parts.Add(string.Format("WriteConcern={0}", _writeConcern));
            if (_writeEncoding.HasBeenSet)
            {
                parts.Add(string.Format("WriteEncoding={0}", (_writeEncoding.Value == null) ? "null" : "UTF8Encoding"));
            }
            return string.Join(";", parts.ToArray());
        }