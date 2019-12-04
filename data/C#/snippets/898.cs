public void Send(string shortMessage, string fullMessage = null, object data = null, Exception ex = null)
        {
            // Verify facility is set:
            if (String.IsNullOrEmpty(this.Facility)) return;

            // Construct log record:
            var logRecord = new Dictionary<string, object>();
            logRecord["version"] = "1.1";
            logRecord["host"] = Environment.MachineName;
            logRecord["_facility"] = this.Facility;
            logRecord["short_message"] = shortMessage;
            if (!String.IsNullOrWhiteSpace(fullMessage)) logRecord["full_message"] = fullMessage;
            logRecord["timestamp"] = EpochOf(DateTime.UtcNow);
            if (data is string) logRecord["_data"] = data;
            else if (data is System.Collections.IDictionary) MergeDictionary(logRecord, (System.Collections.IDictionary)data, "_");
            else if (data is System.Collections.IEnumerable) logRecord["_values"] = data;
            else if (data != null) MergeObject(logRecord, data, "_");

            // Log exception information:
            if (ex != null)
            {
                var prefix = "";
                for (var iex = ex; iex != null; iex = iex.InnerException)
                {
                    logRecord["_ex." + prefix + "msg"] = ex.Message;
                    foreach (var key in iex.Data.Keys)
                    {
                        logRecord["_ex." + prefix + "data." + (key ?? "(null)").ToString()] = iex.Data[key];
                    }
                    prefix = "inner." + prefix;
                }
                logRecord["_ex.full"] = ex.ToString();
            }

            // Serialize object:
            string logRecordString = JsonConvert.SerializeObject(logRecord);
            var logRecordBytes = Encoding.UTF8.GetBytes(logRecordString);

            // Dispatch message:
            this.InternallySendMessage(logRecordBytes);
        }