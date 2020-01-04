public void Remove(int cityRoad_ID)
        {
            foreach (var b12_CityRoad in this)
            {
                if (b12_CityRoad.CityRoad_ID == cityRoad_ID)
                {
                    Remove(b12_CityRoad);
                    break;
                }
            }
        }