protected override void CheckServicePreconditions(ServiceSignature signature)
        {
            if (signature == null)
            {
                throw new ArgumentNullException("signature");
            }

            if (!(signature is AdManagerServiceSignature))
            {
                throw new InvalidCastException(string.Format(CultureInfo.InvariantCulture,
                    AdManagerErrorMessages.SignatureIsOfWrongType,
                    typeof(AdManagerServiceSignature)));
            }
        }