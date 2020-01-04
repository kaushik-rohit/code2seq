public void info(CharSequence info) {
        if (StringUtils.isNotEmpty(info)) {
            msg.printMessage(Diagnostic.Kind.NOTE, Consts.PREFIX_OF_LOGGER + info);
        }
    }