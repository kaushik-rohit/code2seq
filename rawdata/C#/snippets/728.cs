public virtual MongoCollectionSettings Clone()
        {
            var clone = new MongoCollectionSettings();
            clone._collectionName = _collectionName.Clone();
            clone._assignIdOnInsert = _assignIdOnInsert.Clone();
            clone._defaultDocumentType = _defaultDocumentType.Clone();
            clone._guidRepresentation = _guidRepresentation.Clone();
            clone._readEncoding = _readEncoding.Clone();
            clone._readPreference = _readPreference.Clone();
            clone._writeConcern = _writeConcern.Clone();
            clone._writeEncoding = _writeEncoding.Clone();
            return clone;
        }