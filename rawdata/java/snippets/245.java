public static LocalDateTime localDateTimeOf(final String value) {
        var result = (LocalDateTime) null;

        try {
            result = LocalDateTime.parse(value, DateTimeFormatter.ISO_LOCAL_DATE_TIME);
        } catch (final Exception e) {
            result = null;
        }

        if (result == null) {
            try {
                result = LocalDateTime.parse(value, DateTimeFormatter.ISO_ZONED_DATE_TIME);
            } catch (final Exception e) {
                result = null;
            }
        }

        if (result == null) {
            try {
                result = LocalDateTime.parse(value);
            } catch (final Exception e) {
                result = null;
            }
        }

        if (result == null) {
            try {
                result = LocalDateTime.parse(value.toUpperCase(), DateTimeFormatter.ofPattern("MM/dd/yyyy hh:mm a"));
            } catch (final Exception e) {
                result = null;
            }
        }

        if (result == null) {
            try {
                result = LocalDateTime.parse(value.toUpperCase(), DateTimeFormatter.ofPattern("MM/dd/yyyy h:mm a"));
            } catch (final Exception e) {
                result = null;
            }
        }

        if (result == null) {
            try {
                result = LocalDateTime.parse(value, DateTimeFormatter.ofPattern("MM/dd/yyyy HH:mm"));
            } catch (final Exception e) {
                result = null;
            }
        }

        if (result == null) {
            try {
                val ld = LocalDate.parse(value, DateTimeFormatter.ofPattern("MM/dd/yyyy"));
                result = LocalDateTime.of(ld, LocalTime.now());
            } catch (final Exception e) {
                result = null;
            }
        }

        if (result == null) {
            try {
                val ld = LocalDate.parse(value);
                result = LocalDateTime.of(ld, LocalTime.now());
            } catch (final Exception e) {
                result = null;
            }
        }
        return result;
    }