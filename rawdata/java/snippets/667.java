public void unPublishPort() {
        // unregister with epmd
        OtpEpmd.unPublishPort(this);

        // close the local descriptor (if we have one)
        try {
            if (super.epmd != null) {
                super.epmd.close();
            }
        } catch (final IOException e) {/* ignore close errors */
        }
        super.epmd = null;
    }