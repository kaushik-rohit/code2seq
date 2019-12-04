public static SqlGeography ToSqlGeography(this GeometryCollection geometryCollection, int srid = 4326)
		{
			SqlGeographyBuilder gb = new SqlGeographyBuilder();
			gb.SetSrid(srid);
			gb.BeginGeography(OpenGisGeographyType.GeometryCollection);
			foreach (var geom in geometryCollection.Geometries)
			{
				switch (geom.Type)
				{
					case GeoJSONObjectType.LineString:
						Internal_FillGeographyBuilder(gb, geom as LineString);
						break;
					case GeoJSONObjectType.MultiLineString:
						Internal_FillGeographyBuilder(gb, geom as MultiLineString);
						break;
					case GeoJSONObjectType.Point:
						Internal_FillGeographyBuilder(gb, geom as Point);
						break;
					case GeoJSONObjectType.MultiPoint:
						Internal_FillGeographyBuilder(gb, geom as MultiPoint);
						break;
					case GeoJSONObjectType.Polygon:
						Internal_FillGeographyBuilder(gb, geom as Polygon);
						break;
					case GeoJSONObjectType.MultiPolygon:
						Internal_FillGeographyBuilder(gb, geom as MultiPolygon);
						break;
					default:
						throw new NotSupportedException("Geometry conversion is not supported for " + geom.Type.ToString());
				}
			}
			gb.EndGeography();
			return gb.ConstructedGeography;
		}