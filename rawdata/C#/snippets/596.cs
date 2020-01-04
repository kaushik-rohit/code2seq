public virtual void Delete(MailChimpEventQueueRecord record)
        {
            if (record == null)
                throw new ArgumentNullException("record");

            _repository.Delete(record);
        }