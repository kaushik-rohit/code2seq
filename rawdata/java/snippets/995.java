public static int getSurplusQueuedTaskCount() {
        /*
         * The aim of this method is to return a cheap heuristic guide
         * for task partitioning when programmers, frameworks, tools,
         * or languages have little or no idea about task granularity.
         * In essence by offering this method, we ask users only about
         * tradeoffs in overhead vs expected throughput and its
         * variance, rather than how finely to partition tasks.
         *
         * In a steady state strict (tree-structured) computation,
         * each thread makes available for stealing enough tasks for
         * other threads to remain active. Inductively, if all threads
         * play by the same rules, each thread should make available
         * only a constant number of tasks.
         *
         * The minimum useful constant is just 1. But using a value of
         * 1 would require immediate replenishment upon each steal to
         * maintain enough tasks, which is infeasible.  Further,
         * partitionings/granularities of offered tasks should
         * minimize steal rates, which in general means that threads
         * nearer the top of computation tree should generate more
         * than those nearer the bottom. In perfect steady state, each
         * thread is at approximately the same level of computation
         * tree. However, producing extra tasks amortizes the
         * uncertainty of progress and diffusion assumptions.
         *
         * So, users will want to use values larger, but not much
         * larger than 1 to both smooth over transient shortages and
         * hedge against uneven progress; as traded off against the
         * cost of extra task overhead. We leave the user to pick a
         * threshold value to compare with the results of this call to
         * guide decisions, but recommend values such as 3.
         *
         * When all threads are active, it is on average OK to
         * estimate surplus strictly locally. In steady-state, if one
         * thread is maintaining say 2 surplus tasks, then so are
         * others. So we can just use estimated queue length.
         * However, this strategy alone leads to serious mis-estimates
         * in some non-steady-state conditions (ramp-up, ramp-down,
         * other stalls). We can detect many of these by further
         * considering the number of "idle" threads, that are known to
         * have zero queued tasks, so compensate by a factor of
         * (#idle/#active) threads.
         */
        ForkJoinWorkerThread wt =
            (ForkJoinWorkerThread)Thread.currentThread();
        return wt.workQueue.queueSize() - wt.pool.idlePerActive();
    }