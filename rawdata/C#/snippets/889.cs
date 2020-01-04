public IEnumerable<ITag> GetAllContentTags(string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTagsForEntityType(TaggableObjectTypes.Content, tagGroup);
            }
        }