public override Boolean Equals(Object obj)
        {
            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
                return false;


            var wol = (WakeOnLanPacket) obj;

            return DestinationMAC.Equals(wol.DestinationMAC);
        }