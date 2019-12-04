public virtual void Insert(MailChimpEventQueueRecord record)
        {
            if (record == null)
                throw new ArgumentNullException("record");

            _repository.Insert(record);
        }