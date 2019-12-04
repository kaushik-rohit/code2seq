protected override bool ReleaseHandle()
        {
            Gsasl.gsasl_done(handle);
            return true;
        }