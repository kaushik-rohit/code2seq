public IWorkItemResult QueueWorkItem(WorkItemCallback callback, object state, WorkItemPriority workItemPriority)
        {
            PreQueueWorkItem();
            WorkItem workItem = WorkItemFactory.CreateWorkItem(this, WIGStartInfo, callback, state, workItemPriority);
            Enqueue(workItem);
            return workItem.GetWorkItemResult();
        }