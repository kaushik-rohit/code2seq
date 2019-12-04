public static Route Get(ComputeService service, string project, string route)
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

                // Make the request.
                return service.Routes.Get(project, route).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Routes.Get failed.", ex);
            }
        }