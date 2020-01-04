static string GetObjVersString(IEnumerable<ObjVer> objVers )
		{
			// Sanity.
			if(null == objVers)
				throw new ArgumentNullException(nameof(objVers));

			// Need to be of the format:
			// {type1}/{id1}/{version1};{type2}/{id2}/{version2}...
			return String.Join(";", objVers.Select(ov => $"{ov.Type}/{ov.ID}/{ov.Version}"));
		}