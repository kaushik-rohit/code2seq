public void Update(long x)
        {
            while (true)
            {
                long current = this.value.Value;
                if (current >= x)
                {
                    return;
                }

                if (this.value.CompareAndSet(current, x))
                {
                    return;
                }
            }
        }