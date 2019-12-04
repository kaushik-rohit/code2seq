public static List<SqlGeography> ToSqlGeography(this FeatureCollection featureCollection, int srid = 4326)
		{
			List<SqlGeography> retList = new List<SqlGeography>();
			foreach (var feature in featureCollection.Features)
			{
				var sqlGeom = feature.ToSqlGeography(srid);
				if (sqlGeom != null)
					retList.Add(sqlGeom);
			}
			return retList;
		}