public StreetViewResponse GetStreetViewImage(Location location, int width = 600, int height = 400, double? heading = null,
            int? fieldOfView = null, double? pitch = null)
        {

            // Assign query params
            var queryParams = new QueryParams
            {
                ["location"] = Converter.Location(location),
                ["size"] = $"{width}x{height}"
            };

            if (heading.HasValue) queryParams["heading"] = Converter.Number(heading.Value);
            if (fieldOfView.HasValue) queryParams["fov"] = Converter.Number(fieldOfView.Value);
            if (pitch.HasValue) queryParams["pitch"] = Converter.Number(pitch.Value);

            // Get response content
            var responseContent = Client.GetBinary("/maps/api/streetview", queryParams);

            // Return response
            return new StreetViewResponse(responseContent);

        }