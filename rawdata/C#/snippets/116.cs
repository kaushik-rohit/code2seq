public static Operation Delete(ComputeService service, string project, string route, RoutesDeleteOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (project == null)
                    throw new ArgumentNullException(project);
                if (route == null)
                    throw new ArgumentNullException(route);

                // Building the initial request.
                var request = service.Routes.Delete(project, route);

                // Applying optional parameters to the request.                
                request = (RoutesResource.DeleteRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Routes.Delete failed.", ex);
            }
        }