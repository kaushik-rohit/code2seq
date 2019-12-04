public static Boolean IsValid(ByteArraySegment bas)
        {
            // fetch the destination MAC from the payload
            var destinationMAC = new Byte[EthernetFields.MacAddressLength];
            Array.Copy(bas.Bytes, bas.Offset + SyncSequence.Length, destinationMAC, 0, EthernetFields.MacAddressLength);

            // the buffer is used to store both the synchronization sequence
            //  and the MAC address, both of which are the same length (in bytes)
            var buffer = new Byte[EthernetFields.MacAddressLength];

            // validate the 16 repetitions of the wolDestinationMAC
            // - verify that the wolDestinationMAC address repeats 16 times in sequence
            for (var i = 0; i < EthernetFields.MacAddressLength * MACRepetitions; i += EthernetFields.MacAddressLength)
            {
                // Extract the sample from the payload for comparison
                Array.Copy(bas.Bytes, bas.Offset + i, buffer, 0, buffer.Length);

                // check the synchronization sequence on the first pass
                if (i == 0)
                {
                    // validate the synchronization sequence
                    if (!buffer.SequenceEqual(SyncSequence))
                        return false;
                }
                else
                {
                    // fail the validation on malformed WOL Magic Packets
                    if (!buffer.SequenceEqual(destinationMAC))
                        return false;
                }
            }

            return true;
        }