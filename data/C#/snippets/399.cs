public static SqlGeography ToSqlGeography(this Feature.Feature feature, int srid = 4326)
		{
			switch (feature.Geometry.Type)
			{
				case GeoJSONObjectType.LineString:
					return ((LineString)feature.Geometry).ToSqlGeography(srid);

				case GeoJSONObjectType.MultiLineString:
					return ((MultiLineString)feature.Geometry).ToSqlGeography(srid);

				case GeoJSONObjectType.Point:
					return ((Point)feature.Geometry).ToSqlGeography(srid);

				case GeoJSONObjectType.MultiPoint:
					return ((MultiPoint)feature.Geometry).ToSqlGeography(srid);

				case GeoJSONObjectType.Polygon:
					return ((Polygon)feature.Geometry).ToSqlGeography(srid);

				case GeoJSONObjectType.MultiPolygon:
					return ((MultiPolygon)feature.Geometry).ToSqlGeography(srid);

				default:
					throw new NotSupportedException("Geometry conversion is not supported for " + feature.Type.ToString());
			}
		}