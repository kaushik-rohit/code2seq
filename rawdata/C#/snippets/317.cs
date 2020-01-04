public static CreativeFieldValuesListResponse List(DfareportingService service, string profileId, string creativeFieldId, CreativeFieldValuesListOptionalParms optional = null)
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

                // Building the initial request.
                var request = service.CreativeFieldValues.List(profileId, creativeFieldId);

                // Applying optional parameters to the request.                
                request = (CreativeFieldValuesResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request CreativeFieldValues.List failed.", ex);
            }
        }