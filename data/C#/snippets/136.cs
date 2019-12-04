public bool Save(Dynamo Object)
        {
            if (Object == null)
                return false;
            var IDProperty = Properties.FirstOrDefault(x => x is IID);
            if (IDProperty == null)
                return false;
            object IDValue = Object[IDProperty.Name];
            ClassType Item = IDValue == null ? new ClassType() : AnyFunc(IDValue.ToString()).Check(new ClassType());
            if (!CanSaveFunc(Item))
                return false;
            Dynamo SubSet = Object.SubSet(Properties.Where(x => x is IReference)
                                                                   .Select(x => x.Name)
                                                                   .ToArray());
            if (SubSet != null)
                SubSet.CopyTo(Item);
            return SaveFunc(Item);
        }