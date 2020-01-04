private void InitializePopulation()
        {
            var population = new Particle[SwarmSize];
            for (int i = 0; i < population.Length; i++)
            {
                population[i] = new Particle(this, Jobs[i], Maximize, Random);
            }
            Population = population;
        }