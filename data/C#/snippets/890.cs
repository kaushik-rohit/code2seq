public IEnumerable<ITag> GetAllMediaTags(string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTagsForEntityType(TaggableObjectTypes.Media, tagGroup);
            }
        }