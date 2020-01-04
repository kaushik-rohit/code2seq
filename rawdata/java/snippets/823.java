public void setCrumbSalt(String salt) {
        if (Util.fixEmptyAndTrim(salt) == null) {
            crumbSalt = "hudson.crumb";
        } else {
            crumbSalt = salt;
        }
    }