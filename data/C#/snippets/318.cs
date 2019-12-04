public virtual List<T> ProcessResults(string responseJson)
        {
            if (string.IsNullOrWhiteSpace(responseJson)) return new List<T>();

            var csJson = JsonMapper.ToObject(responseJson);

            var ctrlStream = new ControlStream
            {
                Type = Type,
                UserID = UserID,
                StreamID = StreamID
            };

            var csList = new List<ControlStream>
            {
                ctrlStream
            };

            switch (Type)
            {
                case ControlStreamType.Followers:
                    ctrlStream.Follow = new ControlStreamFollow(csJson);
                    break;
                case ControlStreamType.Info:
                    ctrlStream.Info = new ControlStreamInfo(csJson);
                    break;
                default:
                    csList = new List<ControlStream>();
                    break;
            }

            return csList.OfType<T>().ToList();
        }