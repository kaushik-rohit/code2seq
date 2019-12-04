public static SqlGeography ToSqlGeography(this MultiPoint multiPoint, int srid = 4326)
		{
			SqlGeographyBuilder gb = new SqlGeographyBuilder();
			gb.SetSrid(srid);
			Internal_FillGeographyBuilder(gb, multiPoint);
			return gb.ConstructedGeography;
		}