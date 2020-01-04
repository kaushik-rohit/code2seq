private void InitializeSwarm()
        {
            Random = new Random(RandomSeed);
            Pso = true;
            CreateInitialJobs();
            InitializePopulation();
        }