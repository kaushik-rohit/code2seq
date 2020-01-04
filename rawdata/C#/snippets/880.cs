public IEnumerable<TaggedEntity> GetTaggedContentByTag(string tag, string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTaggedEntitiesByTag(TaggableObjectTypes.Content, tag, tagGroup);
            }         
        }