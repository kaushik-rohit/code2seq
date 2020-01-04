public static MsiPropertyInfo GetPropertyInfoByID(int id)
        {
            foreach (MsiPropertyInfo info in DefaultMsiPropertySet)
            {
                if (info.ID == id)
                    return info;
            }
            return null;
        }