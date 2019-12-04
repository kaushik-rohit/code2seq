public virtual void RejectedExecution(IRunnable runnable, ThreadPoolExecutor executor)
        {
            if (executor.IsShutdown) return;
            IRunnable head;
            executor.Queue.Poll(out head);
            executor.Execute(runnable);
        }