private static String escapeXml (String nonEscapedXmlStr) {
        StringBuilder escapedXML = new StringBuilder();
        for (int i = 0; i < nonEscapedXmlStr.length(); i++) {
            char c = nonEscapedXmlStr.charAt(i);
            switch (c) {
                case '<':
                    escapedXML.append("&lt;");
                    break;
                case '>':
                    escapedXML.append("&gt;");
                    break;
                case '\"':
                    escapedXML.append("&quot;");
                    break;
                case '&':
                    escapedXML.append("&amp;");
                    break;
                case '\'':
                    escapedXML.append("&apos;");
                    break;
                default:
                    if (c > 0x7e) {
                        escapedXML.append("&#" + ((int) c) + ";");
                    } else {
                        escapedXML.append(c);
                    }
            }
        }
        return escapedXML.toString();
    }