public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is null)
                throw GetConvertFromException(value);

            if (value is string source)
                return Matrix3x2D.Parse(source);

            return base.ConvertFrom(context, culture, value);
        }