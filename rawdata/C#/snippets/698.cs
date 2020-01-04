public override void Initialize(string name, NameValueCollection config)
	    {
	        base.Initialize(name, config);
	        
            string entityCreationalFactoryTypeString = config["entityFactoryType"];

	        lock(syncObject)
            {
                if (string.IsNullOrEmpty(entityCreationalFactoryTypeString))
				{
                    entityCreationalFactoryType = typeof(Nettiers.AdventureWorks.Entities.EntityFactory);
				}
				else
				{
					foreach (System.Reflection.Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
					{
						if (assembly.FullName.Split(',')[0] == entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')))
						{
							entityCreationalFactoryType = assembly.GetType(entityCreationalFactoryTypeString, false, true);
							break;
						}
					}
				}
				
                if (entityCreationalFactoryType == null)
                {
                    System.Reflection.Assembly entityLibrary = null;
                    //assembly still not found, try loading the assembly.  It's possible it's not referenced.
                    try
                    {
                        //entityLibrary = AppDomain.CurrentDomain.Load(string.Format("{0}.dll", entityCreationalFactoryType.Substring(0, entityCreationalFactoryType.LastIndexOf('.'))));
                        entityLibrary = System.Reflection.Assembly.Load(
                            entityCreationalFactoryTypeString.Substring(0, entityCreationalFactoryTypeString.LastIndexOf('.')));
                    }
                    catch
                    {
                        //throws file not found exception
                    }

                    if (entityLibrary != null)
                    {
                        entityCreationalFactoryType = entityLibrary.GetType(entityCreationalFactoryTypeString, false, true);
                    }
                }
                if (entityCreationalFactoryType == null)
                    throw new ArgumentNullException("Could not find a valid entity factory configured in assemblies.  .netTiers can not continue.");
                
				if (config["enableEntityTracking"] != null)
				{
                	bool.TryParse(config["enableEntityTracking"], out this.enableEntityTracking);
				}
				
				if (config["enableListTracking"] != null)
				{
                	bool.TryParse(config["enableListTracking"], out this.enableListTracking);
				}
				
				if (config["useEntityFactory"] != null)
				{
                	bool.TryParse(config["useEntityFactory"], out this.useEntityFactory);
				}
				
				if (config["enableMethodAuthorization"] != null)
				{
					bool.TryParse(config["enableMethodAuthorization"], out this.enableMethodAuthorization);				
				}
				
				if (config["defaultCommandTimeout"] != null)
				{
					int.TryParse(config["defaultCommandTimeout"], out this.defaultCommandTimeout);
				}
				
				if (String.Compare(config["currentLoadPolicy"], LoadPolicy.DiscardChanges.ToString()) == 0)
                {
                    loadPolicy = LoadPolicy.DiscardChanges;
                }
                
                if (String.Compare(config["currentLoadPolicy"], LoadPolicy.PreserveChanges.ToString()) == 0)
                {
                    loadPolicy = LoadPolicy.PreserveChanges;
                }				
			}   
         }