public void SetException(Exception exception)
        {
            if (exception == null) return;
            //OriginalExceptionType = exception.GetType();
            OriginalExceptionTypeFullName = exception.GetType().FullName;
            Data = exception.Data;
            HelpLink = exception.HelpLink;
            HResult = exception.HResult;
            Message = exception.Message;
            Source = exception.Source;
            StackTrace = exception.StackTrace;
            //TargetSite = exception.TargetSite;
            TargetSiteName = (exception.TargetSite != null) ? exception.TargetSite.Name : "";
            if (exception.InnerException != null)
            {
                InnerException = new SerializableException(exception.InnerException);
            }
        }