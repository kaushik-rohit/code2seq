public IEnumerable<TaggedEntity> GetTaggedMembersByTagGroup(string tagGroup)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTaggedEntitiesByTagGroup(TaggableObjectTypes.Member, tagGroup);
            }    
        }