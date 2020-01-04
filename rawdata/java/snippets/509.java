public static QualifiedName getQualifiedName(DereferenceExpression expression)
    {
        List<String> parts = tryParseParts(expression.base, expression.field.getValue().toLowerCase(Locale.ENGLISH));
        return parts == null ? null : QualifiedName.of(parts);
    }