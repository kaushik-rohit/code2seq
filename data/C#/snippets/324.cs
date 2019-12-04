public static string NormalizePageUrlPath(this string urlPath)
        {
            if (urlPath == null)
            {
                return null;
            }
            if (urlPath.EndsWith(Constants.DefaultExtension))
            {
                urlPath = urlPath.Substring(0, urlPath.Length - Constants.DefaultExtension.Length);
            }
            if (urlPath.EndsWith("/"))
            {
                urlPath += Constants.DefaultExtensionLessPageName;
            }
            return urlPath;
        }