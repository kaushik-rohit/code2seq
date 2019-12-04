public byte[] EncodeMessage( byte[] dataBytes, RSAParameters parameters ) {

				//Determine if we can add padding.
				if( dataBytes.Length > GetMaxMessageLength( parameters ) ) {
					throw new Exception( "Data length is too long. Increase your key size or consider encrypting less data." );
				}

				int padLength = parameters.N.Length - dataBytes.Length - 3;
				BigInteger biRnd = new BigInteger();
				biRnd.genRandomBits( padLength * 8, new Random( DateTime.Now.Millisecond ) );

				byte[] bytRandom = null;
				bytRandom = biRnd.getBytes();

				int z1 = bytRandom.Length;

				//Make sure the bytes are all > 0.
				for( int i = 0; i <= bytRandom.Length - 1; i++ ) {
					if( bytRandom[i] == 0x00 ) {
						bytRandom[i] = 0x01;
					}
				}

				byte[] result = new byte[parameters.N.Length];


				//Add the starting 0x00 byte
				result[0] = 0x00;

				//Add the version code 0x02 byte
				result[1] = 0x02;

				for( int i = 0; i <= bytRandom.Length - 1; i++ ) {
					z1 = i + 2;
					result[z1] = bytRandom[i];
				}

				//Add the trailing 0 byte after the padding.
				result[bytRandom.Length + 2] = 0x00;

				//This starting index for the unpadded data.
				int idx = bytRandom.Length + 3;

				//Copy the unpadded data to the padded byte array.
				dataBytes.CopyTo( result, idx );

				return result;

			}