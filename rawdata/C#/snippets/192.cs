private void OnDrawingDraw(EventArgs args)
        {
            if (this.menu["selected"]["enabled"].GetValue<MenuBool>().Value)
            {
                if (this.selected.Focus && this.selected.Target.IsValidTarget()
                    && this.selected.Target.Position.IsOnScreen())
                {
                    Render.Circle.DrawCircle(
                        this.selected.Target.Position,
                        this.selected.Target.BoundingRadius
                        + this.menu["selected"]["radius"].GetValue<MenuSlider>().Value,
                        this.menu["selected"]["color"].GetValue<MenuColor>().Color.ToSystemColor());
                }
            }

            if (this.weight != null && this.mode.Current.Equals(this.weight))
            {
                if (this.menu["weight"]["simple"].GetValue<MenuBool>().Value)
                {
                    foreach (var target in
                        this.weightTargets.Where(t => t.Item1.IsValidTarget() && t.Item1.Position.IsOnScreen()))
                    {
                        Drawing.DrawText(
                            target.Item1.HPBarPosition.X + 55f,
                            target.Item1.HPBarPosition.Y - 20f,
                            Color.White,
                            target.Item2.ToString("0.0").Replace(",", "."));
                    }
                }

                if (this.menu["weight"]["bestTarget"]["enabled"].GetValue<MenuBool>().Value
                    && this.weightBestTarget.IsValidTarget() && this.weightBestTarget.Position.IsOnScreen())
                {
                    Render.Circle.DrawCircle(
                        this.weightBestTarget.Position,
                        this.weightBestTarget.BoundingRadius
                        + this.menu["weight"]["bestTarget"]["radius"].GetValue<MenuSlider>().Value,
                        this.menu["weight"]["bestTarget"]["color"].GetValue<MenuColor>().Color.ToSystemColor());
                }
            }
        }