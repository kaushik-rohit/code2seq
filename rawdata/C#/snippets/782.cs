protected void Child_Fetch(int continent_ID1)
        {
            var args = new DataPortalHookArgs(continent_ID1);
            OnFetchPre(args);
            using (var dalManager = DalFactorySelfLoadROSoftDelete.GetManager())
            {
                var dal = dalManager.GetProvider<IG03_Continent_ChildDal>();
                var data = dal.Fetch(continent_ID1);
                Fetch(data);
            }
            OnFetchPost(args);
        }