public ResponseBuilder Body(IHttpBodyConverter httpBodyConverter)
        {
            _body = httpBodyConverter.Body;
            Header("Content-Type", httpBodyConverter.ContentType);
            return this;
        }