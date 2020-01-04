protected override string GetIdentityRetrievalScalarStatement()
        {
            return string.IsNullOrEmpty(PrimaryKeyFieldSequence)
                ? string.Empty
                : $"SELECT {PrimaryKeyFieldSequence} as newID";
        }