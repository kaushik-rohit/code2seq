public virtual void Validate()
        {
            if (TargetConnectionInfo == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TargetConnectionInfo");
            }
            if (TargetDatabaseName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "TargetDatabaseName");
            }
            if (ProjectName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ProjectName");
            }
            if (ProjectLocation == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "ProjectLocation");
            }
            if (SelectedTables == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "SelectedTables");
            }
            if (TargetConnectionInfo != null)
            {
                TargetConnectionInfo.Validate();
            }
        }