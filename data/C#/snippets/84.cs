public static IAuthToken Custom(string principal, string credentials, string realm, string scheme,
            Dictionary<string, object> parameters)
        {
            var token = new Dictionary<string, object>
            {
                {SchemeKey, scheme},
                {PrincipalKey, principal},
                {CredentialsKey, credentials},
                {RealmKey, realm}
            };
            if (parameters != null)
            {
                token.Add(ParametersKey, parameters);
            }
            return new AuthToken(token);
        }