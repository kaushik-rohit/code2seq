public static SqlGeography ToSqlGeography(this MultiLineString multiLineString, int srid = 4326)
		{
			SqlGeographyBuilder gb = new SqlGeographyBuilder();
			gb.SetSrid(srid);
			Internal_FillGeographyBuilder(gb, multiLineString);
			return gb.ConstructedGeography;
		}