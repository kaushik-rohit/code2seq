private static String[] splitMultipartHeader(String sb) {
        ArrayList<String> headers = new ArrayList<String>(1);
        int nameStart;
        int nameEnd;
        int colonEnd;
        int valueStart;
        int valueEnd;
        nameStart = HttpPostBodyUtil.findNonWhitespace(sb, 0);
        for (nameEnd = nameStart; nameEnd < sb.length(); nameEnd++) {
            char ch = sb.charAt(nameEnd);
            if (ch == ':' || Character.isWhitespace(ch)) {
                break;
            }
        }
        for (colonEnd = nameEnd; colonEnd < sb.length(); colonEnd++) {
            if (sb.charAt(colonEnd) == ':') {
                colonEnd++;
                break;
            }
        }
        valueStart = HttpPostBodyUtil.findNonWhitespace(sb, colonEnd);
        valueEnd = HttpPostBodyUtil.findEndOfString(sb);
        headers.add(sb.substring(nameStart, nameEnd));
        String svalue = (valueStart >= valueEnd) ? StringUtil.EMPTY_STRING : sb.substring(valueStart, valueEnd);
        String[] values;
        if (svalue.indexOf(';') >= 0) {
            values = splitMultipartHeaderValues(svalue);
        } else {
            values = svalue.split(",");
        }
        for (String value : values) {
            headers.add(value.trim());
        }
        String[] array = new String[headers.size()];
        for (int i = 0; i < headers.size(); i++) {
            array[i] = headers.get(i);
        }
        return array;
    }