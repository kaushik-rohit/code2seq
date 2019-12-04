private void OnGameUpdate(EventArgs args)
        {
            if (this.weight == null || !this.mode.Current.Equals(this.weight))
            {
                return;
            }

            if (!this.menu["weight"]["simple"].GetValue<MenuBool>().Value
                && !this.menu["weight"]["bestTarget"]["enabled"].GetValue<MenuBool>().Value)
            {
                return;
            }

            var weightRange = this.menu["weight"]["range"].GetValue<MenuSlider>().Value;
            var enemies = GameObjects.EnemyHeroes.Where(e => e.IsValidTarget(weightRange)).ToList();
            foreach (var w in this.weight.Items)
            {
                this.weight.UpdateMaxMinValue(w, enemies, true);
            }

            this.weightTargets = (from enemy in enemies
                                  let w =
                                      this.weight.Items.Where(w => w.Weight > 0)
                                      .Sum(w => this.weight.Calculate(w, enemy, true))
                                  let hp = this.weight.GetHeroPercent(enemy)
                                  let sw = hp > 0 ? w / 100 * hp : 0
                                  select new Tuple<Obj_AI_Hero, float>(enemy, sw)).OrderByDescending(w => w.Item2)
                .ToList();

            var bestTarget = this.weightTargets.Any() ? this.weightTargets.Select(e => e.Item1).FirstOrDefault() : null;
            if (!bestTarget.Compare(this.weightBestTarget)
                && Variables.TickCount - this.weightBestTargetLastTickCount >= 1000)
            {
                this.weightBestTarget = bestTarget;
                this.weightBestTargetLastTickCount = Variables.TickCount;
            }
        }