public IEnumerable<ITag> GetTagsForEntity(Guid contentId, string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTagsForEntity(contentId, tagGroup);
            }
        }