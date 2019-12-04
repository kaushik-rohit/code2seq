public override int GetHashCode()
        {
            if (_isFrozen)
            {
                return _frozenHashCode;
            }

            // see Effective Java by Joshua Bloch
            int hash = 17;
            hash = 37 * hash + ((_collectionName.Value == null) ? 0 : _collectionName.Value.GetHashCode());
            hash = 37 * hash + _assignIdOnInsert.Value.GetHashCode();
            hash = 37 * hash + ((_defaultDocumentType.Value == null) ? 0 : _defaultDocumentType.Value.GetHashCode());
            hash = 37 * hash + _guidRepresentation.Value.GetHashCode();
            hash = 37 * hash + ((_readEncoding.Value == null) ? 0 : _readEncoding.Value.GetHashCode());
            hash = 37 * hash + ((_readPreference.Value == null) ? 0 : _readPreference.Value.GetHashCode());
            hash = 37 * hash + ((_writeConcern.Value == null) ? 0 :_writeConcern.Value.GetHashCode());
            hash = 37 * hash + ((_writeEncoding.Value == null) ? 0 : _writeEncoding.Value.GetHashCode());
            return hash;
        }