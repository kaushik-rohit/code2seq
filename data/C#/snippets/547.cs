public void decompressApplicationSessions()
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
                            if (request.CompressedRequest != null && request.CompressedRequest.Length > 0)
                            {
                                request.RequestBody = compressor.decompress(request.CompressedRequest) as string;
                                request.CompressedRequest = null;
                            }
                            if (request.CompressedResponse != null && request.CompressedResponse.Length > 0)
                            {
                                request.ResponseBody = compressor.decompress(request.CompressedResponse) as string;
                                request.CompressedResponse = null;
                            }
                        }
                    }
                }
            }
        }