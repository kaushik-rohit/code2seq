public IEnumerable<TaggedEntity> GetTaggedMembersByTag(string tag, string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTaggedEntitiesByTag(TaggableObjectTypes.Member, tag, tagGroup);
            }    
        }