public static Object typeConvert(Object val, String esType) {
        if (val == null) {
            return null;
        }
        if (esType == null) {
            return val;
        }
        Object res = null;
        if ("integer".equals(esType)) {
            if (val instanceof Number) {
                res = ((Number) val).intValue();
            } else {
                res = Integer.parseInt(val.toString());
            }
        } else if ("long".equals(esType)) {
            if (val instanceof Number) {
                res = ((Number) val).longValue();
            } else {
                res = Long.parseLong(val.toString());
            }
        } else if ("short".equals(esType)) {
            if (val instanceof Number) {
                res = ((Number) val).shortValue();
            } else {
                res = Short.parseShort(val.toString());
            }
        } else if ("byte".equals(esType)) {
            if (val instanceof Number) {
                res = ((Number) val).byteValue();
            } else {
                res = Byte.parseByte(val.toString());
            }
        } else if ("double".equals(esType)) {
            if (val instanceof Number) {
                res = ((Number) val).doubleValue();
            } else {
                res = Double.parseDouble(val.toString());
            }
        } else if ("float".equals(esType) || "half_float".equals(esType) || "scaled_float".equals(esType)) {
            if (val instanceof Number) {
                res = ((Number) val).floatValue();
            } else {
                res = Float.parseFloat(val.toString());
            }
        } else if ("boolean".equals(esType)) {
            if (val instanceof Boolean) {
                res = val;
            } else if (val instanceof Number) {
                int v = ((Number) val).intValue();
                res = v != 0;
            } else {
                res = Boolean.parseBoolean(val.toString());
            }
        } else if ("date".equals(esType)) {
            if (val instanceof java.sql.Time) {
                DateTime dateTime = new DateTime(((java.sql.Time) val).getTime());
                if (dateTime.getMillisOfSecond() != 0) {
                    res = dateTime.toString("HH:mm:ss.SSS");
                } else {
                    res = dateTime.toString("HH:mm:ss");
                }
            } else if (val instanceof java.sql.Timestamp) {
                DateTime dateTime = new DateTime(((java.sql.Timestamp) val).getTime());
                if (dateTime.getMillisOfSecond() != 0) {
                    res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss.SSS" + Util.timeZone);
                } else {
                    res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss" + Util.timeZone);
                }
            } else if (val instanceof java.sql.Date || val instanceof Date) {
                DateTime dateTime;
                if (val instanceof java.sql.Date) {
                    dateTime = new DateTime(((java.sql.Date) val).getTime());
                } else {
                    dateTime = new DateTime(((Date) val).getTime());
                }
                if (dateTime.getHourOfDay() == 0 && dateTime.getMinuteOfHour() == 0 && dateTime.getSecondOfMinute() == 0
                    && dateTime.getMillisOfSecond() == 0) {
                    res = dateTime.toString("yyyy-MM-dd");
                } else {
                    if (dateTime.getMillisOfSecond() != 0) {
                        res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss.SSS" + Util.timeZone);
                    } else {
                        res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss" + Util.timeZone);
                    }
                }
            } else if (val instanceof Long) {
                DateTime dateTime = new DateTime(((Long) val).longValue());
                if (dateTime.getHourOfDay() == 0 && dateTime.getMinuteOfHour() == 0 && dateTime.getSecondOfMinute() == 0
                    && dateTime.getMillisOfSecond() == 0) {
                    res = dateTime.toString("yyyy-MM-dd");
                } else if (dateTime.getMillisOfSecond() != 0) {
                    res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss.SSS" + Util.timeZone);
                } else {
                    res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss" + Util.timeZone);
                }
            } else if (val instanceof String) {
                String v = ((String) val).trim();
                if (v.length() > 18 && v.charAt(4) == '-' && v.charAt(7) == '-' && v.charAt(10) == ' '
                    && v.charAt(13) == ':' && v.charAt(16) == ':') {
                    String dt = v.substring(0, 10) + "T" + v.substring(11);
                    Date date = Util.parseDate(dt);
                    if (date != null) {
                        DateTime dateTime = new DateTime(date);
                        if (dateTime.getMillisOfSecond() != 0) {
                            res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss.SSS" + Util.timeZone);
                        } else {
                            res = dateTime.toString("yyyy-MM-dd'T'HH:mm:ss" + Util.timeZone);
                        }
                    }
                } else if (v.length() == 10 && v.charAt(4) == '-' && v.charAt(7) == '-') {
                    Date date = Util.parseDate(v);
                    if (date != null) {
                        DateTime dateTime = new DateTime(date);
                        res = dateTime.toString("yyyy-MM-dd");
                    }
                }
            }
        } else if ("binary".equals(esType)) {
            if (val instanceof byte[]) {
                Base64 base64 = new Base64();
                res = base64.encodeAsString((byte[]) val);
            } else if (val instanceof Blob) {
                byte[] b = blobToBytes((Blob) val);
                Base64 base64 = new Base64();
                res = base64.encodeAsString(b);
            } else if (val instanceof String) {
                // 对应canal中的单字节编码
                byte[] b = ((String) val).getBytes(StandardCharsets.ISO_8859_1);
                Base64 base64 = new Base64();
                res = base64.encodeAsString(b);
            }
        } else if ("geo_point".equals(esType)) {
            if (!(val instanceof String)) {
                logger.error("es type is geo_point, but source type is not String");
                return val;
            }

            if (!((String) val).contains(",")) {
                logger.error("es type is geo_point, source value not contains ',' separator");
                return val;
            }

            String[] point = ((String) val).split(",");
            Map<String, Double> location = new HashMap<>();
            location.put("lat", Double.valueOf(point[0].trim()));
            location.put("lon", Double.valueOf(point[1].trim()));
            return location;
        } else if ("array".equals(esType)) {
            if ("".equals(val.toString().trim())) {
                res = new ArrayList<>();
            } else {
                String value = val.toString();
                String separator = ",";
                if (!value.contains(",")) {
                    if (value.contains(";")) {
                        separator = ";";
                    } else if (value.contains("|")) {
                        separator = "\\|";
                    } else if (value.contains("-")) {
                        separator = "-";
                    }
                }
                String[] values = value.split(separator);
                return Arrays.asList(values);
            }
        } else if ("object".equals(esType)) {
            if ("".equals(val.toString().trim())) {
                res = new HashMap<>();
            } else {
                res = JSON.parseObject(val.toString(), Map.class);
            }
        } else {
            // 其他类全以字符串处理
            res = val.toString();
        }

        return res;
    }