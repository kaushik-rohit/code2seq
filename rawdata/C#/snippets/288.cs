private void GetLocalizabilityForAttachedProperty(
            string                      propertyName, 
            Type                        owner,
            out LocalizabilityAttribute localizability,
            out Type                    propertyType
            )
        {
            localizability = null;
            propertyType   = null;
        
            // if it is an attached property, it should have a dependency property with the name 
            // <attached proeprty's name> + "Property"
            DependencyProperty attachedDp = DependencyPropertyFromName(
                propertyName, // property name
                owner
                );       // owner type
                       
            if (attachedDp == null)
                return;  // couldn't find the dp.

            // we found the Dp, set the type of the property
            propertyType = attachedDp.PropertyType;

            FieldInfo fieldInfo = attachedDp.OwnerType.GetField(
                attachedDp.Name + "Property", 
                BindingFlags.Public | BindingFlags.NonPublic | 
                BindingFlags.Static | BindingFlags.FlattenHierarchy);

            Debug.Assert(fieldInfo != null);           
            
            object[] attributes = fieldInfo.GetCustomAttributes(
                TypeOfLocalizabilityAttribute, // type of localizability
                true
                );                // inherit
                
            if (attributes.Length == 0)
            {
                // didn't find it.
                return;
            }
            else
            {
                Debug.Assert(attributes.Length == 1, "Should have only 1 localizability attribute");
                localizability = (LocalizabilityAttribute) attributes[0];                
            }                       
        }