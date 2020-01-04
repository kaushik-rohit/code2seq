public static SqlGeography ToSqlGeography(this MultiPolygon multiPolygon, int srid = 4326)
		{
			SqlGeographyBuilder gb = new SqlGeographyBuilder();
			gb.SetSrid(srid);
			gb.BeginGeography(OpenGisGeographyType.MultiPolygon);
			foreach (var polygon in multiPolygon.Coordinates)
			{
				Internal_FillGeographyBuilder(gb, polygon);
			}
			gb.EndGeography();
			return gb.ConstructedGeography;
		}