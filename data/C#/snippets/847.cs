public ResponseBuilder Status(HttpStatusCode status)
        {
            _status = (int)status;
            return this;
        }