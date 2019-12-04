public bool ContainsDeleted(int cityRoad_ID)
        {
            foreach (var b12_CityRoad in DeletedList)
            {
                if (b12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    return true;
                }
            }
            return false;
        }