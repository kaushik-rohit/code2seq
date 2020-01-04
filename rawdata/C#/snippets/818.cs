public override void EncodeFields(Name value, enc.IJsonWriter writer)
            {
                WriteProperty("given_name", value.GivenName, writer, enc.StringEncoder.Instance);
                WriteProperty("surname", value.Surname, writer, enc.StringEncoder.Instance);
                WriteProperty("familiar_name", value.FamiliarName, writer, enc.StringEncoder.Instance);
                WriteProperty("display_name", value.DisplayName, writer, enc.StringEncoder.Instance);
                WriteProperty("abbreviated_name", value.AbbreviatedName, writer, enc.StringEncoder.Instance);
            }