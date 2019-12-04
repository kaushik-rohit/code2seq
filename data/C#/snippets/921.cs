public bool Verify(RSACryptoServiceProvider rsa, HashAlgorithm hash) {
      byte[] unsigned_data = (byte[]) UnsignedData;
      byte[] signature = (byte[]) Signature;
      return rsa.VerifyData(unsigned_data, hash, signature);
    }