public override bool Equals(object obj)
        {
            var rhs = obj as MongoCollectionSettings;
            if (rhs == null)
            {
                return false;
            }
            else
            {
                if (_isFrozen && rhs._isFrozen)
                {
                    return _frozenStringRepresentation == rhs._frozenStringRepresentation;
                }
                else
                {
                    return
                        _collectionName.Value == rhs._collectionName.Value &&
                        _assignIdOnInsert.Value == rhs._assignIdOnInsert.Value &&
                        _defaultDocumentType.Value == rhs._defaultDocumentType.Value &&
                        _guidRepresentation.Value == rhs._guidRepresentation.Value &&
                        object.Equals(_readEncoding, rhs._readEncoding) &&
                        _readPreference.Value == rhs._readPreference.Value &&
                        _writeConcern.Value == rhs._writeConcern.Value &&
                        object.Equals(_writeEncoding, rhs._writeEncoding);
                }
            }
        }