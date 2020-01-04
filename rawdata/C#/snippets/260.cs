public override void Initialize(GeneticAlgorithm algorithm)
        {
            base.Initialize(algorithm);

            int initialCount = this.GetInitialLength();
            this.genes = new List<TItem>(initialCount);

            for (int i = 0; i < initialCount; i++)
            {
                this.genes.Add(default(TItem));
            }
        }