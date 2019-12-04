public byte[] EncodeMessage( byte[] dataBytes, RSAParameters parameters ) {
				//Iterator
				int i = 0;

				//Get the size of the data to be encrypted
				m_mLen = dataBytes.Length;

				//Get the size of the public modulus (will serve as max length for cipher text)
				m_k = parameters.N.Length;

				if( m_mLen > GetMaxMessageLength( parameters ) ) {
					throw new Exception( "Bad Data." );
				}

				//Generate the random octet seed (same length as hash)
				BigInteger biSeed = new BigInteger();
				biSeed.genRandomBits( m_hLen * 8, new Random() );
				byte[] bytSeed = biSeed.getBytesRaw();

				//Make sure all of the bytes are greater than 0.
				for( i = 0; i <= bytSeed.Length - 1; i++ ) {
					if( bytSeed[i] == 0x00 ) {
						//Replacing with the prime byte 17, no real reason...just picked at random.
						bytSeed[i] = 0x17;
					}
				}

				//Mask the seed with MFG Function(SHA1 Hash)
				//This is the mask to be XOR'd with the DataBlock below.
				byte[] dbMask = CryptoMathematics.OAEPMGF( bytSeed, m_k - m_hLen - 1, m_hLen, m_hashProvider );

				//Compute the length needed for PS (zero padding) and 
				//fill a byte array to the computed length
				int psLen = GetMaxMessageLength( parameters ) - m_mLen;

				//Generate the SHA1 hash of an empty L (Label).  Label is not used for this 
				//application of padding in the RSA specification.
				byte[] lHash = m_hashProvider.ComputeHash( System.Text.Encoding.UTF8.GetBytes( string.Empty.ToCharArray() ) );

				//Create a dataBlock which will later be masked.  The 
				//data block includes the concatenated hash(L), PS, 
				//a 0x01 byte, and the message.
				int dbLen = m_hLen + psLen + 1 + m_mLen;
				byte[] dataBlock = new byte[dbLen];

				int cPos = 0;
				//Current position

				//Add the L Hash to the data blcok
				for( i = 0; i <= lHash.Length - 1; i++ ) {
					dataBlock[cPos] = lHash[i];
					cPos += 1;
				}

				//Add the zero padding
				for( i = 0; i <= psLen - 1; i++ ) {
					dataBlock[cPos] = 0x00;
					cPos += 1;
				}

				//Add the 0x01 byte
				dataBlock[cPos] = 0x01;
				cPos += 1;

				//Add the message
				for( i = 0; i <= dataBytes.Length - 1; i++ ) {
					dataBlock[cPos] = dataBytes[i];
					cPos += 1;
				}

				//Create the masked data block.
				byte[] maskedDB = CryptoMathematics.BitwiseXOR( dbMask, dataBlock );

				//Create the seed mask
				byte[] seedMask = CryptoMathematics.OAEPMGF( maskedDB, m_hLen, m_hLen, m_hashProvider );

				//Create the masked seed
				byte[] maskedSeed = CryptoMathematics.BitwiseXOR( bytSeed, seedMask );

				//Create the resulting cipher - starting with a 0 byte.
				byte[] result = new byte[parameters.N.Length];
				result[0] = 0x00;

				//Add the masked seed
				maskedSeed.CopyTo( result, 1 );

				//Add the masked data block
				maskedDB.CopyTo( result, maskedSeed.Length + 1 );

				return result;
			}