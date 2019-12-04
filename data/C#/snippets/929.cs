public static WakeOnLanPacket RandomPacket()
        {
            var rnd = new Random();

            var destAddress = new Byte[EthernetFields.MacAddressLength];

            rnd.NextBytes(destAddress);

            return new WakeOnLanPacket(new PhysicalAddress(destAddress));
        }