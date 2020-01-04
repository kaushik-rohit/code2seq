public void ClearAnimationList()
        {
            foreach (Animation anim in Animations)
            {
                RemoveAnimation(anim);
            }
        }