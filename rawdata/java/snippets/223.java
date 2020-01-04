private String quotedAV() {
    pos++;
    beg = pos;
    end = beg;
    while (true) {

      if (pos == length) {
        throw new IllegalStateException("Unexpected end of DN: " + dn);
      }

      if (chars[pos] == '"') {
        // enclosing quotation was found
        pos++;
        break;
      } else if (chars[pos] == '\\') {
        chars[end] = getEscaped();
      } else {
        // shift char: required for string with escaped chars
        chars[end] = chars[pos];
      }
      pos++;
      end++;
    }

    // skip trailing space chars before comma or semicolon.
    // (compatibility with RFC 1779)
    for (; pos < length && chars[pos] == ' '; pos++) {
    }

    return new String(chars, beg, end - beg);
  }