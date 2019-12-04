private void GetLocalizabilityForClrProperty(
            string                      propertyName, 
            Type                        owner,
            out LocalizabilityAttribute localizability,
            out Type                    propertyType
            )
        {
            localizability = null;
            propertyType   = null;
            
            PropertyInfo info = owner.GetProperty(propertyName);
            if (info == null)
            {
                return; // couldn't find the Clr property
            }

            // we found the CLR property, set the type of the property
            propertyType = info.PropertyType;

            object[] locAttributes = info.GetCustomAttributes(
                TypeOfLocalizabilityAttribute, // type of the attribute
                true                    // search in base class
            );

            if (locAttributes.Length == 0)
            {
                return;
            }
            else
            {
                Debug.Assert(locAttributes.Length == 1, "Should have only 1 localizability attribute");

                // we found the attribute defined on the property
                localizability = (LocalizabilityAttribute) locAttributes[0];                                
            }                                
        }