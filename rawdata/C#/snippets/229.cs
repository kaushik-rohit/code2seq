protected FileInfo DeriveVcsFromEnvironment () {
            FileInfo vcsFile =
                DeriveFullPathFromEnv(VcsHomeEnv, VcsExeName);
            if (null == vcsFile) {
                vcsFile = DeriveFullPathFromEnv(PathVariable, VcsExeName);
            }
            return vcsFile;
        }