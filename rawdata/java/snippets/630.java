@Override
    public void encode(final OtpOutputStream buf) {
        final int arity = arity();

        buf.write_map_head(arity);

        for (final Map.Entry<OtpErlangObject, OtpErlangObject> e : entrySet()) {
            buf.write_any(e.getKey());
            buf.write_any(e.getValue());
        }
    }