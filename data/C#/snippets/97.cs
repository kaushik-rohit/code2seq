public bool Delete(string ID)
        {
            if (string.IsNullOrEmpty(ID))
                throw new ArgumentNullException(nameof(ID));
            var DeleteValue = AnyFunc(ID);
            if (CanDeleteFunc(DeleteValue))
                return DeleteFunc(DeleteValue);
            return false;
        }