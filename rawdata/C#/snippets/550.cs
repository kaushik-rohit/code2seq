public override string ToString()
        {
            StringBuilder sb = new StringBuilder("MDWS Session: " + _aspNetSessionId);
            sb.AppendLine();
            sb.AppendLine("Requesting IP: " + _requestingIP);
            sb.AppendLine("Session Started: " + _start.ToString());
            sb.AppendLine("Session Ended: " + _end.ToString());
            if (_requests != null && _requests.Count > 0)
            {
                sb.AppendLine("Session Requests:");
                foreach (ApplicationRequest request in _requests)
                {
                    sb.AppendLine(request.ToString());
                }
            }
            return sb.ToString();
        }