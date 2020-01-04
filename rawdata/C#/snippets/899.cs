public void Send(Exception ex, SyslogLevel level = SyslogLevel.Error)
        {
            // Send exception:
            if (ex != null) this.Send(ex.Message, null, new { level = level }, ex);
        }