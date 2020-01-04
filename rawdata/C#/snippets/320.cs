public virtual void Validate()
        {
            if (StorageKey == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StorageKey");
            }
            if (StorageUri == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "StorageUri");
            }
            if (AdministratorLogin == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AdministratorLogin");
            }
            if (AdministratorLoginPassword == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AdministratorLoginPassword");
            }
        }