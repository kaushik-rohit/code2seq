public IEnumerable<ITag> GetTagsForProperty(Guid contentId, string propertyTypeAlias, string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTagsForProperty(contentId, propertyTypeAlias, tagGroup);
            }
        }