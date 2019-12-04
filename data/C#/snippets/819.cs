protected override void SetField(Name value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "given_name":
                        value.GivenName = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "surname":
                        value.Surname = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "familiar_name":
                        value.FamiliarName = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "display_name":
                        value.DisplayName = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "abbreviated_name":
                        value.AbbreviatedName = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }