public IEnumerable<ITag> GetAllTags(string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTagsForEntityType(TaggableObjectTypes.All, tagGroup);
            }  
        }