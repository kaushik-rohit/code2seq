public static void Delete(DfareportingService service, string profileId, string creativeFieldId, string id)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (profileId == null)
                    throw new ArgumentNullException(profileId);
                if (creativeFieldId == null)
                    throw new ArgumentNullException(creativeFieldId);
                if (id == null)
                    throw new ArgumentNullException(id);

                // Make the request.
                 service.CreativeFieldValues.Delete(profileId, creativeFieldId, id).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CreativeFieldValues.Delete failed.", ex);
            }
        }