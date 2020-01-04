public static EmptyMessage NewACK(Message message)
        {
            EmptyMessage ack = new EmptyMessage(MessageType.ACK);
            ack.ID = message.ID;
            ack.Token = CoapConstants.EmptyToken;
            ack.Destination = message.Source;
            return ack;
        }