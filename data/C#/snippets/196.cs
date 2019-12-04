public GsaslSession BeginSession(string mechanism)
        {
            GsaslSession session;
            var rc = Gsasl.gsasl_client_start(
                this,
                mechanism,
                out session);

            if (rc != Gsasl.GSASL_OK)
            {
                var message = Gsasl.GetError(rc);
                throw new GsaslException(rc, message);
            }

            return session;
        }