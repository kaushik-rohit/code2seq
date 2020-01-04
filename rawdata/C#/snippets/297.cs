private void UpdateSwarm()
        {
            Parallel.For(0, Population.Length, i =>
            {
                // Update the current particle if it has seen the best parameter for itself so far
                Population[i].UpdateIfBest();
            });
            GetGlobalBest(out float[] globalBest, out float[] generationBest);
            // Now that we have the best, find the closest M to our best and update our position
            for (int i = 0; i < Population.Length; i++)
            {
                // Figure our who the closest neighbors are
                Population[i].UpdateVelocity(this, globalBest, generationBest, Random);
                Jobs[i] = Population[i].UpdatePosition(this, Random);
            }
        }