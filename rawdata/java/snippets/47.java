public static String decodeName(ByteBuf in) {
        int position = -1;
        int checked = 0;
        final int end = in.writerIndex();
        final int readable = in.readableBytes();

        // Looking at the spec we should always have at least enough readable bytes to read a byte here but it seems
        // some servers do not respect this for empty names. So just workaround this and return an empty name in this
        // case.
        //
        // See:
        // - https://github.com/netty/netty/issues/5014
        // - https://www.ietf.org/rfc/rfc1035.txt , Section 3.1
        if (readable == 0) {
            return ROOT;
        }

        final StringBuilder name = new StringBuilder(readable << 1);
        while (in.isReadable()) {
            final int len = in.readUnsignedByte();
            final boolean pointer = (len & 0xc0) == 0xc0;
            if (pointer) {
                if (position == -1) {
                    position = in.readerIndex() + 1;
                }

                if (!in.isReadable()) {
                    throw new CorruptedFrameException("truncated pointer in a name");
                }

                final int next = (len & 0x3f) << 8 | in.readUnsignedByte();
                if (next >= end) {
                    throw new CorruptedFrameException("name has an out-of-range pointer");
                }
                in.readerIndex(next);

                // check for loops
                checked += 2;
                if (checked >= end) {
                    throw new CorruptedFrameException("name contains a loop.");
                }
            } else if (len != 0) {
                if (!in.isReadable(len)) {
                    throw new CorruptedFrameException("truncated label in a name");
                }
                name.append(in.toString(in.readerIndex(), len, CharsetUtil.UTF_8)).append('.');
                in.skipBytes(len);
            } else { // len == 0
                break;
            }
        }

        if (position != -1) {
            in.readerIndex(position);
        }

        if (name.length() == 0) {
            return ROOT;
        }

        if (name.charAt(name.length() - 1) != '.') {
            name.append('.');
        }

        return name.toString();
    }