public void Sign(RSACryptoServiceProvider rsa, HashAlgorithm hash) {
      byte[] unsigned_data = (byte[]) UnsignedData;
      byte[] signature = rsa.SignData(unsigned_data, hash);
      Signature = MemBlock.Reference(signature); 
    }