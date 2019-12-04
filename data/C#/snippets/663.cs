private bool Validate()
        {
            IPAddress ip;
            ushort p;
            brokenRules["Device"] = device == null ? "No input device selected" : "";
            brokenRules["Host"] = !IPAddress.TryParse(Host, out ip) ? "Invalid IP Address" : "";
            brokenRules["Port"] = !ushort.TryParse(Port, out p) ? "Invalid port number" : "";

         return brokenRules.All(r => string.IsNullOrEmpty(r.Value));
        }