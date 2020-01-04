public override string ToString()
        {
            var baseQuery = base.ToString();

            var sb = new StringBuilder(baseQuery);

            if (ResponseGroup != null)
            {
                if(ResponseGroup == Enums.ResponseGroup.HighResolution)
                    sb.Append($"&response_group=high_resolution");
                else
                    sb.Append($"&response_group=image_details");
            }
            if (ImageType != null)
            {
                sb.Append($"&image_type={ImageType.ToString().ToLower()}");
            }
            if (Orientation != null)
            {
                sb.Append($"&orientation={Orientation.ToString().ToLower()}");
            }

            return sb.ToString();
        }