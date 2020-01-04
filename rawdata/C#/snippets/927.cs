public static ConvertMethod GetConverter()
		{
			Type from = typeof(P);
			Type to   = typeof(T);

			// Convert to the same type.
			//
			if (to == from)
				return (ConvertMethod)(object)(Convert<P,P>.ConvertMethod)SameType;

			if (from.IsEnum)
				from = Enum.GetUnderlyingType(from);

			if (to.IsEnum)
				to = Enum.GetUnderlyingType(to);

			if (TypeHelper.IsSameOrParent(to, from))
				return Assignable;

			string methodName;

			if (TypeHelper.IsNullable(to))
				methodName = "ToNullable" + to.GetGenericArguments()[0].Name;
			else if (to.IsArray)
				methodName = "To" + to.GetElementType().Name + "Array";
			else
				methodName = "To" + to.Name;

			MethodInfo mi = typeof(Convert).GetMethod(methodName,
				BindingFlags.Public | BindingFlags.Static | BindingFlags.ExactBinding,
				null, new Type[] {from}, null) ?? FindTypeCastOperator(to) ?? FindTypeCastOperator(from);

			if (mi == null && TypeHelper.IsNullable(to))
			{
				// To-nullable conversion.
				// We have to use reflection to enforce some constraints.
				//
				Type toType   = to.GetGenericArguments()[0];
				Type fromType = TypeHelper.IsNullable(from)? from.GetGenericArguments()[0]: from;
				methodName = TypeHelper.IsNullable(from) ? "FromNullable" : "From";

				mi = typeof(NullableConvert<,>)
					.MakeGenericType(toType, fromType)
					.GetMethod(methodName, BindingFlags.Public | BindingFlags.Static);
			}

			if (mi != null)
				return (ConvertMethod)Delegate.CreateDelegate(typeof(ConvertMethod), mi);

			return Default;
		}