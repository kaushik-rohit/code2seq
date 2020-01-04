public virtual IList<MailChimpEventQueueRecord> GetAll()
        {
            var query = from r in _repository.Table
                        orderby r.CreatedOnUtc descending 
                        select r;

            return query.ToList();
        }