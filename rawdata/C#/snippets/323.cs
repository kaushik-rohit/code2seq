public static CreativeFieldValue Patch(DfareportingService service, string profileId, string creativeFieldId, string id, CreativeFieldValue body)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (body == null)
                    throw new ArgumentNullException("body");
                if (profileId == null)
                    throw new ArgumentNullException(profileId);
                if (creativeFieldId == null)
                    throw new ArgumentNullException(creativeFieldId);
                if (id == null)
                    throw new ArgumentNullException(id);

                // Make the request.
                return service.CreativeFieldValues.Patch(body, profileId, creativeFieldId, id).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CreativeFieldValues.Patch failed.", ex);
            }
        }