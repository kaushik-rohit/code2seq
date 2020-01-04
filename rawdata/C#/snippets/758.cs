public int Insert(IdentityUser user, string roleId)
        {
            string commandText = "Insert into UserRoles (UserId, RoleId) values (@userId, @roleId)";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("userId", user.Id);
            parameters.Add("roleId", roleId);

            return _database.Execute(commandText, parameters);
        }