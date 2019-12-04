public void compressApplicationSessions()
        {
            if (_sessions != null && _sessions.Count > 0)
            {
                gov.va.medora.utils.Compression compressor = new gov.va.medora.utils.Compression();
                foreach (ApplicationSession session in _sessions.Values)
                {
                    if (session.Requests != null && session.Requests.Count > 0)
                    {
                        foreach (ApplicationRequest request in session.Requests)
                        {
                            if (!String.IsNullOrEmpty(request.RequestBody))
                            {
                                request.CompressedRequest = compressor.compress(request.RequestBody);
                                request.RequestBody = "";
                            }
                            if (!String.IsNullOrEmpty(request.ResponseBody))
                            {
                                request.CompressedResponse = compressor.compress(request.ResponseBody);
                                request.ResponseBody = "";
                            }
                        }
                    }
                }
            }
        }