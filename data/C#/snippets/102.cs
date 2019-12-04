public bool DeleteProperty(string ID, MappingHolder MappingHolder, string PropertyName, string PropertyID)
        {
            if (string.IsNullOrEmpty(ID))
                throw new ArgumentNullException(nameof(ID));
            var PropertyObject = Properties.FirstOrDefault(x => string.Equals(x.Name, PropertyName, StringComparison.InvariantCultureIgnoreCase));
            if (PropertyObject == null)
                return false;
            var Object = AnyFunc(ID);
            if (!CanGetFunc(Object))
                return false;
            return PropertyObject.DeleteValue(MappingHolder, Object, PropertyID);
        }