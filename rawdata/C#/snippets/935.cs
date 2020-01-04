private string GetFormattedExpression(FieldAttributeInfo fieldAttribute)
    {
      switch (fieldAttribute.FieldType)
	    {
        case FieldType.Double:
        case FieldType.Integer:
        case FieldType.Single:
        case FieldType.SmallInteger:
        case FieldType.OID:
          if (fieldAttribute.FieldValue == null)
            return string.Format("{0} is NULL", fieldAttribute.FieldName);
          else
            return string.Format("{0} = {1}", fieldAttribute.FieldName, fieldAttribute.FieldValue);
        case FieldType.String:
          if (fieldAttribute.FieldValue == null)
            return string.Format("{0} is NULL", fieldAttribute.FieldName);
          else
            return string.Format("{0} = {1}", fieldAttribute.FieldName, string.Format("'{0}'", fieldAttribute.FieldValue));
        default:
          return null;
	    }
    }