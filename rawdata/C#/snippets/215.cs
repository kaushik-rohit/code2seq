public static void MakeRequest<TRequest, TResponse>(string verb,
                string requestUrl, TRequest obj, Action<TResponse> action)
        {
            Type type = typeof (TRequest);

            WebRequest request = WebRequest.Create(requestUrl);
            WebResponse response = null;
            TResponse deserial = default(TResponse);
            XmlSerializer deserializer = new XmlSerializer(typeof (TResponse));

            request.Method = verb;

            if (verb == "POST")
            {
                request.ContentType = "text/xml";

                MemoryStream buffer = new MemoryStream();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = Encoding.UTF8;

                using (XmlWriter writer = XmlWriter.Create(buffer, settings))
                {
                    XmlSerializer serializer = new XmlSerializer(type);
                    serializer.Serialize(writer, obj);
                    writer.Flush();
                }

                int length = (int) buffer.Length;
                request.ContentLength = length;

                request.BeginGetRequestStream(delegate(IAsyncResult res)
                {
                    Stream requestStream = request.EndGetRequestStream(res);

                    requestStream.Write(buffer.ToArray(), 0, length);

                    request.BeginGetResponse(delegate(IAsyncResult ar)
                    {
                        response = request.EndGetResponse(ar);

                        try
                        {
                            deserial = (TResponse) deserializer.Deserialize(
                                    response.GetResponseStream());
                        }
                        catch (System.InvalidOperationException)
                        {
                        }

                        action(deserial);
                    }, null);
                }, null);

                return;
            }

            request.BeginGetResponse(delegate(IAsyncResult res2)
            {
                response = request.EndGetResponse(res2);

                try
                {
                    deserial = (TResponse) deserializer.Deserialize(
                            response.GetResponseStream());
                }
                catch (System.InvalidOperationException)
                {
                }

                action(deserial);
            }, null);
        }