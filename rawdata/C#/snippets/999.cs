public override IGTFSFeed Filter(IGTFSFeed feed)
        {
            var filteredFeed = new GTFSFeed();

            // filter routes.
            var routeIds = new HashSet<string>();
            var agencyIds = new HashSet<string>();
            foreach (var route in feed.Routes)
            {
                if (_routesFilter.Invoke(route))
                { // keep this route.
                    filteredFeed.Routes.Add(route);
                    routeIds.Add(route.Id);

                    // keep agency ids.
                    agencyIds.Add(route.AgencyId);
                }
            }

            // filter trips.
            var serviceIds = new HashSet<string>();
            var tripIds = new HashSet<string>();
            var shapeIds = new HashSet<string>();
            foreach (var trip in feed.Trips)
            {
                if (routeIds.Contains(trip.RouteId))
                { // keep this trip, it is related to at least one stop-time.
                    filteredFeed.Trips.Add(trip);
                    tripIds.Add(trip.Id);

                    // keep serviceId, routeId and shapeId.
                    serviceIds.Add(trip.ServiceId);
                    if (!string.IsNullOrWhiteSpace(trip.ShapeId))
                    {
                        shapeIds.Add(trip.ShapeId);
                    }
                }
            }

            // filter stop-times.
            var stopIds = new HashSet<string>();
            foreach (var stopTime in feed.StopTimes)
            {
                if (tripIds.Contains(stopTime.TripId))
                { // stop is included, keep this stopTime.
                    filteredFeed.StopTimes.Add(stopTime);

                    // save the trip id's to keep.
                    stopIds.Add(stopTime.StopId);
                }
            }


            // filter stops.
            foreach (var stop in feed.Stops)
            {
                if (stopIds.Contains(stop.Id))
                { // stop has to be included.
                    stopIds.Add(stop.Id);
                    filteredFeed.Stops.Add(stop);
                }
            }

            // filter agencies.
            foreach (var agency in feed.Agencies)
            {
                if (agencyIds.Contains(agency.Id))
                { // keep this agency.
                    filteredFeed.Agencies.Add(agency);
                }
            }

            // filter calendars.
            foreach (var calendar in feed.Calendars)
            {
                if (serviceIds.Contains(calendar.ServiceId))
                { // keep this calendar.                    
                    filteredFeed.Calendars.Add(calendar);
                }
            }

            // filter calendar-dates.
            foreach (var calendarDate in feed.CalendarDates)
            {
                if (serviceIds.Contains(calendarDate.ServiceId))
                { // keep this calendarDate.                    
                    filteredFeed.CalendarDates.Add(calendarDate);
                }
            }

            // filter fare rules.
            var fareIds = new HashSet<string>();
            foreach (var fareRule in feed.FareRules)
            {
                if (routeIds.Contains(fareRule.RouteId))
                { // keep this fare rule.
                    filteredFeed.FareRules.Add(fareRule);

                    // keep fare ids.
                    fareIds.Add(fareRule.FareId);
                }
            }

            // filter fare attributes.
            foreach (var fareAttribute in feed.FareAttributes)
            {
                if (fareIds.Contains(fareAttribute.FareId))
                { // keep this fare attribute.
                    filteredFeed.FareAttributes.Add(fareAttribute);
                }
            }

            // filter frequencies.
            foreach (var frequency in feed.Frequencies)
            {
                if (tripIds.Contains(frequency.TripId))
                { // keep this frequency.
                    filteredFeed.Frequencies.Add(frequency);
                }
            }

            foreach (var transfer in feed.Transfers)
            {
                if (stopIds.Contains(transfer.FromStopId) &&
                    stopIds.Contains(transfer.ToStopId))
                {
                    filteredFeed.Transfers.Add(transfer);
                }
            }
            return filteredFeed;
        }