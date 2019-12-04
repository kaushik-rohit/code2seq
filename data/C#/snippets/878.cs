public IEnumerable<TaggedEntity> GetTaggedContentByTagGroup(string tagGroup)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTaggedEntitiesByTagGroup(TaggableObjectTypes.Content, tagGroup);
            }         
        }