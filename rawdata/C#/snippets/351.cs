public byte[] DecodeMessage( byte[] dataBytes, RSAParameters parameters ) {

				byte[] bytDec = new byte[parameters.N.Length];

				int lenDiff = 0;

				dataBytes.CopyTo( bytDec, lenDiff );

				if( ( bytDec[0] != 0x0 ) && ( bytDec[1] != 0x02 ) ) {
					throw new Exception( "Invalid padding. Supplied data does not contain valid PKCS#1 v1.5 padding. Padding could not be removed." );
				}

				//Find out where the padding ends.
				int idxEnd = 0;
				int dataLength = 0;

				for( int i = 2; i < bytDec.Length; i++ ) {
					if( bytDec[i] == 0x00 ) {
						idxEnd = i;
						break;
					}
				}

				//Calculate the length of the unpadded data
				dataLength = bytDec.Length - idxEnd - 2;

				byte[] result = new byte[dataLength + 1];

				int idxRslt = 0;

				//Put the unpadded data into the result array
				for( int i = idxEnd + 1; i <= bytDec.Length - 1; i++ ) {
					result[idxRslt] = bytDec[i];
					idxRslt += 1;
				}

				return result;

			}