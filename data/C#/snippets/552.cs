public override string ToString()
        {
            StringBuilder sb = new StringBuilder(_uri.ToString());
            if(!String.IsNullOrEmpty(_requestBody))
            {
                sb.Append(Environment.NewLine + "Request Body:" + Environment.NewLine + _requestBody);
            }
            if(!String.IsNullOrEmpty(_responseBody))
            {
                sb.Append(Environment.NewLine + "Response Body:" + Environment.NewLine + _responseBody);
            }
            return sb.ToString();
        }