internal void LoadItems(B09_CityColl collection)
        {
            foreach (var item in this)
            {
                var obj = collection.FindB10_CityByParentProperties(item.parent_City_ID);
                var rlce = obj.B11_CityRoadObjects.RaiseListChangedEvents;
                obj.B11_CityRoadObjects.RaiseListChangedEvents = false;
                obj.B11_CityRoadObjects.Add(item);
                obj.B11_CityRoadObjects.RaiseListChangedEvents = rlce;
            }
        }