public byte[] DecodeMessage( byte[] dataBytes, RSAParameters parameters ) {

				m_k = parameters.D.Length;
				if( !( m_k == dataBytes.Length ) ) {
					throw new Exception( "Bad Data." );
				}

				//Length of the datablock
				int iDBLen = dataBytes.Length - m_hLen - 1;

				//Starting index for the data block.  This will be equal to m_hLen + 1.  The 
				//index is zero based, and the dataBytes should start with a single leading byte, 
				//plus the maskedSeed (equal to hash length m_hLen).
				int iDBidx = m_hLen + 1;

				//Single byte for leading byte
				byte bytY = 0;

				//Byte array matching the length of the hashing algorithm.
				//This array will hold the masked seed.
				byte[] maskedSeed = new byte[m_hLen];

				//Byte array matching the length of the following:
				//Private Exponent D minus Hash Length, minus 1 (for the leading byte)
				byte[] maskedDB = new byte[iDBLen];

				//Copy the leading byte
				bytY = dataBytes[0];

				//Copy the mask
				Array.Copy( dataBytes, 1, maskedSeed, 0, m_hLen );

				//Copy the data block
				Array.Copy( dataBytes, iDBidx, maskedDB, 0, iDBLen );

				//Reproduce the seed mask from the masked data block using the mask generation function
				byte[] seedMask = CryptoMathematics.OAEPMGF( maskedDB, m_hLen, m_hLen, m_hashProvider );

				//Reproduce the Seed from the Seed Mask.
				byte[] seed = CryptoMathematics.BitwiseXOR( maskedSeed, seedMask );

				//Reproduce the data block bask from the seed using the mask generation function
				byte[] dbMask = CryptoMathematics.OAEPMGF( seed, m_k - m_hLen - 1, m_hLen, m_hashProvider );

				//Reproduce the data block from the masked data block and the seed
				byte[] dataBlock = CryptoMathematics.BitwiseXOR( maskedDB, dbMask );

				//Pull the message from the data block.  First m_hLen bytes are the lHash, 
				//followed by padding of 0x00's, followed by a single 0x01, then the message.
				//So we're going to start and index m_hLen and work forward.
				if( !( dataBlock[m_hLen] == 0x00 ) ) {
					throw new Exception( "Decryption Error. Bad Data." );
				}

				//If we passed the 0x00 first byte test, iterate through the 
				//data block and find the terminating character.
				int iDataIdx = 0;


				for( int i = m_hLen; i <= dataBlock.Length - 1; i++ ) {
					if( dataBlock[i] == 0x01 ) {
						iDataIdx = i + 1;
						break;
					}
				}

				//Now find the length of the data and copy it to a byte array.
				int iDataLen = dataBlock.Length - iDataIdx;
				byte[] result = new byte[iDataLen];
				Array.Copy( dataBlock, iDataIdx, result, 0, iDataLen );

				return result;

			}