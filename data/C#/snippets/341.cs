protected override List<XAttribute> GetElementAttributes()
        {
            var attributes = new List<XAttribute>();
            if (this.Url != null)
            {
                attributes.Add(new XAttribute("url", Serializers.Url(this.Url)));
            }
            if (this.Method != null)
            {
                attributes.Add(new XAttribute("method", this.Method.ToString()));
            }
            if (this.ReservationSid != null)
            {
                attributes.Add(new XAttribute("reservationSid", this.ReservationSid));
            }
            if (this.PostWorkActivitySid != null)
            {
                attributes.Add(new XAttribute("postWorkActivitySid", this.PostWorkActivitySid));
            }
            return attributes;
        }