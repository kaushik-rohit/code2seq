public override void Register(RegistrationContext context)
        {
            var key = context.CreateKey(_regKeyName);
            key.SetValue("DeveloperActivity", _developerActivity);
        }