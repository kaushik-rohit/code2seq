public IWorkItemResult QueueWorkItem(WorkItemCallback callback, WorkItemPriority workItemPriority)
        {
            PreQueueWorkItem();
            WorkItem workItem = WorkItemFactory.CreateWorkItem(this, WIGStartInfo, callback, workItemPriority);
            Enqueue(workItem);
            return workItem.GetWorkItemResult();
        }