public static CreativeFieldValue Insert(DfareportingService service, string profileId, string creativeFieldId, CreativeFieldValue body)
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

                // Make the request.
                return service.CreativeFieldValues.Insert(body, profileId, creativeFieldId).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CreativeFieldValues.Insert failed.", ex);
            }
        }