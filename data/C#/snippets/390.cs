public static SqlGeography ToSqlGeography(this Polygon polygon, int srid = 4326)
		{
			SqlGeographyBuilder gb = new SqlGeographyBuilder();
			gb.SetSrid(srid);
			Internal_FillGeographyBuilder(gb, polygon);
			return gb.ConstructedGeography;
		}