public static T[] FromArray(P[] src)
		{
			// Note that type parameters are in reverse order.
			//
			return Array.ConvertAll<P,T>(src, (Converter<P,T>)((object)From));
		}