public async Task<List> GetAsync()
        {
            var request = Connection.CreateRequest("realestate/{realEstateId}/attachment/attachmentsorder");
            request.AddParameter("realEstateId", RealEstate.Id, ParameterType.UrlSegment);
            return await ExecuteAsync<List>(Connection, request);
        }