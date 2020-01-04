@StaplerDispatchable
    public Object getFingerprint( String md5sum ) throws IOException {
        Fingerprint r = fingerprintMap.get(md5sum);
        if(r==null)     return new NoFingerprintMatch(md5sum);
        else            return r;
    }