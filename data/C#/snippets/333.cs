[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
    public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
    {
      base.GetObjectData(serializationInfo, streamingContext);
      serializationInfo.AddValue("innerExceptions", (object) this.innerExceptions, typeof (SmtpFailedRecipientException[]));
    }