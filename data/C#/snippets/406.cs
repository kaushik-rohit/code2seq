public override string ToString()
        {
            if (this.errors == null || this.errors.Length == 0)
            {
                return base.ToString();
            }
            else
            {
                return string.Join<ApiError>("\n", errors);
            }
        }