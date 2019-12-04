internal static B11_CityRoadColl GetB11_CityRoadColl(List<B12_CityRoadDto> data)
        {
            B11_CityRoadColl obj = new B11_CityRoadColl();
            // show the framework that this is a child object
            obj.MarkAsChild();
            obj.Fetch(data);
            return obj;
        }