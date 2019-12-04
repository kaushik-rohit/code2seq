public static SqlGeography ToSqlGeography(this Point point, int srid = 4326)
		{
			SqlGeographyBuilder gb = new SqlGeographyBuilder();
			gb.SetSrid(srid);

			Internal_FillGeographyBuilder(gb, point);

			return gb.ConstructedGeography;
		}