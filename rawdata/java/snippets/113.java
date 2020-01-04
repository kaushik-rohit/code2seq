public void parse(String s) {
        Preconditions.checkNotNull(s, "s");
        if (s.length() == 0) {
            // Nothing to do.
            return;
        }

        val pairs = s.split(pairDelimiter);
        for (String pair : pairs) {
            int delimiterPos = pair.indexOf(keyValueDelimiter);
            if (delimiterPos < 0) {
                throw new IllegalArgumentException(String.format("Invalid pair '%s' (missing key-value delimiter).", pair));
            }

            String key = pair.substring(0, delimiterPos);
            String value;
            if (delimiterPos == pair.length() - 1) {
                value = "";
            } else {
                value = pair.substring(delimiterPos + 1);
            }

            Extractor<?> e = this.extractors.get(key);
            Preconditions.checkArgument(e != null, String.format("No extractor provided for key '%s'.", key));
            e.process(value);
        }
    }