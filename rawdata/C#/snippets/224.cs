protected void AppendFiles () {
            foreach (string pathname in VcsFileSet.FileNames) {
                string relativePath = pathname.Replace(DestinationDirectory.FullName, "");
                if (relativePath.IndexOf('/') == 0 || relativePath.IndexOf('\\') == 0) {
                    relativePath = relativePath.Substring(1, relativePath.Length - 1);
                }
                relativePath = relativePath.Replace("\\", "/");
                Arguments.Add(new Argument("\"" + relativePath + "\""));
            }
        }