public static GsaslContext Initialize()
        {
            GsaslContext context;
            var rc = Gsasl.gsasl_init(out context);
            if (rc != Gsasl.GSASL_OK)
            {
                var message = Gsasl.GetError(rc);
                throw new GsaslException(rc, message);
            }

            return context;
        }