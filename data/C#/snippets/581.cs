public virtual bool synchronizeToEA(Package ownerPackage,string elementType)
		{
			//first check if it exists already
			string sqlGetExistingElement = @"select o.Object_ID from (t_object o 
											inner join t_objectproperties tv on o.Object_ID = tv.Object_ID)
											where tv.[Property] = 'TFS_ID'
											and tv.[Value] = '"+ this.ID +"'";
			//TODO: get elements by query
			var elementToWrap = ownerPackage.EAModel.getElementWrappersByQuery(sqlGetExistingElement).FirstOrDefault();
			if (elementToWrap == null)
			{
				//element does not exist, create a new one
				elementToWrap = ownerPackage.addOwnedElement<ElementWrapper>(this.title,elementType);
			}
			if (elementToWrap != null)
			{
				this.wrappedElement = elementToWrap;
				this.save();
			}
			//return if this worked
			return elementToWrap != null;
		}