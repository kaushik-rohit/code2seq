public IEnumerable<TaggedEntity> GetTaggedMediaByTag(string tag, string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTaggedEntitiesByTag(TaggableObjectTypes.Media, tag, tagGroup);
            }    
        }