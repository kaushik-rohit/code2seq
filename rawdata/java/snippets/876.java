@Override
    public boolean matches(final CharSequence rawPassword, final String encodedPassword) {
        if (StringUtils.isBlank(encodedPassword)) {
            LOGGER.warn("The encoded password provided for matching is null. Returning false");
            return false;
        }
        var providedSalt = StringUtils.EMPTY;
        val lastDollarIndex = encodedPassword.lastIndexOf('$');
        if (lastDollarIndex == -1) {
            providedSalt = encodedPassword.substring(0, 2);
            LOGGER.debug("Assuming DES UnixCrypt as no delimiter could be found in the encoded password provided");
        } else {
            providedSalt = encodedPassword.substring(0, lastDollarIndex);
            LOGGER.debug("Encoded password uses algorithm [{}]", providedSalt.charAt(1));
        }
        var encodedRawPassword = Crypt.crypt(rawPassword.toString(), providedSalt);
        var matched = StringUtils.equals(encodedRawPassword, encodedPassword);
        LOGGER.debug("Provided password does {}match the encoded password", BooleanUtils.toString(matched, StringUtils.EMPTY, "not "));
        return matched;
    }