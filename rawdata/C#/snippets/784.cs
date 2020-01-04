public override string ToString()
		{
			if (Equals(Unknown)) return "unknown";
			if (Equals(Top)) return "top";
			if (Equals(Bottom)) return "bottom";
			return Value.ToLowerString();
		}