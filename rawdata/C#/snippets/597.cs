public async Task UpdateAsync(List attachmentsOrder)
        {
            var request = Connection.CreateRequest("realestate/{realEstateId}/attachment/attachmentsorder", Method.PUT);
            request.AddParameter("realEstateId", RealEstate.Id, ParameterType.UrlSegment);
            request.AddBody(attachmentsOrder);
            var resp = await ExecuteAsync<Messages>(Connection, request);
            if (!resp.IsSuccessful())
            {
                throw new IS24Exception(string.Format("Error updating attachmentsorder for real estate {0}: {1}",
                    RealEstate.Id, resp.ToMessage())) {Messages = resp};
            }
        }