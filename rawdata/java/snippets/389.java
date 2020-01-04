public byte[] sign(byte[] headerBytes, byte[] payloadBytes) throws SignatureGenerationException {
    	// default implementation; keep around until sign(byte[]) method is removed
    	byte[] contentBytes = new byte[headerBytes.length + 1 + payloadBytes.length];
    	
    	System.arraycopy(headerBytes, 0, contentBytes, 0, headerBytes.length);
    	contentBytes[headerBytes.length] = (byte)'.';
    	System.arraycopy(payloadBytes, 0, contentBytes, headerBytes.length + 1, payloadBytes.length);
    	
    	return sign(contentBytes);
    }