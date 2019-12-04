public override void Render(TextWriter output, string format = null, IFormatProvider formatProvider = null)
        {
            if (output == null) throw new ArgumentNullException(nameof(output));

            if (Value == null)
            {
                output.Write("null");
                return;
            }

            if (Value is string s)
            {
                if (format != "l")
                {
                    output.Write("\"");
                    output.Write(s.Replace("\"", "\\\""));
                    output.Write("\"");
                }
                else
                {
                    output.Write(s);
                }
                return;
            }

            if (formatProvider != null)
            {
                var custom = (ICustomFormatter)formatProvider.GetFormat(typeof(ICustomFormatter));
                if (custom != null)
                {
                    output.Write(custom.Format(format, Value, formatProvider));
                    return;
                }
            }

            if (Value is IFormattable f)
            {
                output.Write(f.ToString(format, formatProvider ?? CultureInfo.InvariantCulture));
            }
            else
            {
                output.Write(Value.ToString());
            }
        }