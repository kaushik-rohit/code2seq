public static IAuthToken Basic(string username, string password, string realm)
        {
            var token = new Dictionary<string, object>
            {
                {SchemeKey, "basic"},
                {PrincipalKey, username},
                {CredentialsKey, password}
            };
            if (realm != null)
            {
                token.Add(RealmKey, realm);
            }
            return new AuthToken(token);
        }