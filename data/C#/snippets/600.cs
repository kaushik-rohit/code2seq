public virtual void QueueAll()
        {
            //NOTE: While I dislike executing straight SQL from C#, I think straight SQL is the best solution for this particular action.
            // My logic is that #1 this query takes no arguments, it is a batch query and #2 this is potentially a very big operation.
            // Loading all of the NewsLetterSubscriptions, iterating them, converting them, and submitting the changes just seems like we would not be taking advantage of our tools (SQLServer).
            _context.Database.ExecuteSqlCommand(QUEUE_ALL_RECORDS);
            _context.SaveChanges();
        }