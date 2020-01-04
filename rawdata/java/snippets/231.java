public void open(File file, final long filePosition) throws FileNotFoundException, IOException {
        fin = new FileInputStream(file);

        ensureCapacity(BIN_LOG_HEADER_SIZE);
        if (BIN_LOG_HEADER_SIZE != fin.read(buffer, 0, BIN_LOG_HEADER_SIZE)) {
            throw new IOException("No binlog file header");
        }

        if (buffer[0] != BINLOG_MAGIC[0] || buffer[1] != BINLOG_MAGIC[1] || buffer[2] != BINLOG_MAGIC[2]
            || buffer[3] != BINLOG_MAGIC[3]) {
            throw new IOException("Error binlog file header: "
                                  + Arrays.toString(Arrays.copyOf(buffer, BIN_LOG_HEADER_SIZE)));
        }

        limit = 0;
        origin = 0;
        position = 0;

        if (filePosition > BIN_LOG_HEADER_SIZE) {
            final int maxFormatDescriptionEventLen = FormatDescriptionLogEvent.LOG_EVENT_MINIMAL_HEADER_LEN
                                                     + FormatDescriptionLogEvent.ST_COMMON_HEADER_LEN_OFFSET
                                                     + LogEvent.ENUM_END_EVENT + LogEvent.BINLOG_CHECKSUM_ALG_DESC_LEN
                                                     + LogEvent.CHECKSUM_CRC32_SIGNATURE_LEN;

            ensureCapacity(maxFormatDescriptionEventLen);
            limit = fin.read(buffer, 0, maxFormatDescriptionEventLen);
            limit = (int) getUint32(LogEvent.EVENT_LEN_OFFSET);
            fin.getChannel().position(filePosition);
        }
    }