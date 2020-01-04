public static Area parse(String s) {
        Matcher m = PATTERN.matcher(s);
        if(m.matches())
            return new Area(Integer.parseInt(m.group(1)),Integer.parseInt(m.group(2)));
        return null;
    }