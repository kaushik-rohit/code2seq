public Exception PukeException()
        {
            var exception = InnerException != null
                ? new Exception(Message, InnerException.PukeException())
                : new Exception(Message);
            exception.HelpLink = HelpLink;
            exception.Source = Source;
            return exception;
        }