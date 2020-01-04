public override LocalizabilityAttribute GetPropertyLocalizability(
            string assembly,
            string className,
            string property           
            )
        {
            LocalizabilityAttribute attribute = null;

            Type type =  GetType(assembly, className);
         
            if (type != null)
            {
                // type of the property. The type can be retrieved from CLR property, or Attached property.
                Type clrPropertyType = null, attachedPropertyType = null;     
                    
                // we found the type. try to get to the property as Clr property                    
                GetLocalizabilityForClrProperty(
                    property, 
                    type,
                    out attribute,
                    out clrPropertyType
                    );

                if (attribute == null)
                {
                    // we didn't find localizability as a Clr property on the type,
                    // try to get the property as attached property
                    GetLocalizabilityForAttachedProperty(
                            property, 
                            type,
                            out attribute,
                            out attachedPropertyType
                            );
                }

                if (attribute == null)
                {
                    // if attached property doesn't have [LocalizabilityAttribute] defined,
                    // we get it from the type of the property.
                    attribute =(clrPropertyType != null) ?
                          GetLocalizabilityFromType(clrPropertyType)
                        : GetLocalizabilityFromType(attachedPropertyType);
                }
            }

            return attribute;
        }