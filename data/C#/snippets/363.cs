public override bool SetClip (OxyRect rect)
        {
            Context.Save ();
            Context.Rectangle (rect.Left, rect.Top, rect.Width, rect.Height);
            Context.Clip ();
            return true;
        }