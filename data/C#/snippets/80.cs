public static IAuthToken Kerberos(string base64EncodedTicket)
        {
            var token = new Dictionary<string, object>
            {
                {SchemeKey, "kerberos"},
                {PrincipalKey, ""}, //This empty string is required for backwards compatibility.
                {CredentialsKey, base64EncodedTicket}
            };
            return new AuthToken(token);
        }