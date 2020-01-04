protected override void OnElementChanged(ElementChangedEventArgs<Image> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
                return;

            var ellipse = new Ellipse();
            SetNativeControl(ellipse);

        }