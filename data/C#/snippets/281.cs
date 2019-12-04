private LocalizabilityAttribute GetLocalizabilityFromType(Type type)
        {                 
           if (type == null) return null;
           
           // let's get to its localizability attribute.
           object[] locAttributes = type.GetCustomAttributes(
               TypeOfLocalizabilityAttribute, // type of localizability
               true                           // search for inherited value
               );
                    
           if (locAttributes.Length == 0)
           {
               return DefaultAttributes.GetDefaultAttribute(type);
           }                    
           else                
           {
               Debug.Assert(locAttributes.Length == 1, "Should have only 1 localizability attribute");
                   
               // use the one defined on the class
               return (LocalizabilityAttribute) locAttributes[0];
           }         
               
        }