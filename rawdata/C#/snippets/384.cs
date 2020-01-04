public static SqlGeography ToSqlGeography(this LineString lineString, int srid = 4326)
		{
			SqlGeographyBuilder gb = new SqlGeographyBuilder();
			gb.SetSrid(srid);
			Internal_FillGeographyBuilder(gb, lineString);
			return gb.ConstructedGeography;
		}