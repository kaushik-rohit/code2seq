public AnimationSheet Clone()
        {
            AnimationSheet sheetClone = new AnimationSheet(Name) { ExportSettings = ExportSettings };

            foreach (var animation in _animations)
            {
                sheetClone.AddAnimation(animation.Clone());
            }

            return sheetClone;
        }