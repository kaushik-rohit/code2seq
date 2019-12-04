public override void CopyTo(GeneticEntity entity)
        {
            this.EnsureEntityIsInitialized();
            base.CopyTo(entity);

            ListEntity<TItem> listEntity = (ListEntity<TItem>)entity;
            TItem[] values = new TItem[this.genes.Count];
            this.genes.CopyTo(values);
            listEntity.genes = values.ToList();
            listEntity.UpdateStringRepresentation();
        }