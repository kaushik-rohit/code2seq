public static EmptyMessage NewRST(Message message)
        {
            EmptyMessage rst = new EmptyMessage(MessageType.RST);
            rst.ID = message.ID;
            rst.Token = CoapConstants.EmptyToken;
            rst.Destination = message.Source;
            return rst;
        }