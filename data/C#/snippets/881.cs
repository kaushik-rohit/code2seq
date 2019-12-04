public IEnumerable<TaggedEntity> GetTaggedMediaByTagGroup(string tagGroup)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTaggedEntitiesByTagGroup(TaggableObjectTypes.Media, tagGroup);
            }    
        }