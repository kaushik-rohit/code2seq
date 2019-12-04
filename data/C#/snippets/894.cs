public IEnumerable<ITag> GetTagsForEntity(int contentId, string tagGroup = null)
        {
            using (var repository = RepositoryFactory.CreateTagRepository(UowProvider.GetUnitOfWork()))
            {
                return repository.GetTagsForEntity(contentId, tagGroup);
            }
        }