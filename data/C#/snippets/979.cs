private void Fetch(List<B12_CityRoadDto> data)
        {
            var rlce = RaiseListChangedEvents;
            RaiseListChangedEvents = false;
            var args = new DataPortalHookArgs(data);
            OnFetchPre(args);
            foreach (var dto in data)
            {
                Add(B12_CityRoad.GetB12_CityRoad(dto));
            }
            OnFetchPost(args);
            RaiseListChangedEvents = rlce;
        }