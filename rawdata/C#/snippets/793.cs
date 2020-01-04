private void FetchChildren(SafeDataReader dr)
        {
            dr.NextResult();
            if (dr.Read())
                LoadProperty(E03_Continent_SingleObjectProperty, E03_Continent_Child.GetE03_Continent_Child(dr));
            dr.NextResult();
            if (dr.Read())
                LoadProperty(E03_Continent_ASingleObjectProperty, E03_Continent_ReChild.GetE03_Continent_ReChild(dr));
            dr.NextResult();
            LoadProperty(E03_SubContinentObjectsProperty, E03_SubContinentColl.GetE03_SubContinentColl(dr));
            dr.NextResult();
            while (dr.Read())
            {
                var child = E05_SubContinent_Child.GetE05_SubContinent_Child(dr);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E05_SubContinent_ReChild.GetE05_SubContinent_ReChild(dr);
                var obj = E03_SubContinentObjects.FindE04_SubContinentByParentProperties(child.subContinent_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e05_CountryColl = E05_CountryColl.GetE05_CountryColl(dr);
            e05_CountryColl.LoadItems(E03_SubContinentObjects);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E07_Country_Child.GetE07_Country_Child(dr);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E07_Country_ReChild.GetE07_Country_ReChild(dr);
                var obj = e05_CountryColl.FindE06_CountryByParentProperties(child.country_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e07_RegionColl = E07_RegionColl.GetE07_RegionColl(dr);
            e07_RegionColl.LoadItems(e05_CountryColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E09_Region_Child.GetE09_Region_Child(dr);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E09_Region_ReChild.GetE09_Region_ReChild(dr);
                var obj = e07_RegionColl.FindE08_RegionByParentProperties(child.region_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e09_CityColl = E09_CityColl.GetE09_CityColl(dr);
            e09_CityColl.LoadItems(e07_RegionColl);
            dr.NextResult();
            while (dr.Read())
            {
                var child = E11_City_Child.GetE11_City_Child(dr);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID1);
                obj.LoadChild(child);
            }
            dr.NextResult();
            while (dr.Read())
            {
                var child = E11_City_ReChild.GetE11_City_ReChild(dr);
                var obj = e09_CityColl.FindE10_CityByParentProperties(child.city_ID2);
                obj.LoadChild(child);
            }
            dr.NextResult();
            var e11_CityRoadColl = E11_CityRoadColl.GetE11_CityRoadColl(dr);
            e11_CityRoadColl.LoadItems(e09_CityColl);
        }