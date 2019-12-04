internal static UIKit.UIInterfaceOrientation ToUIKit(this DisplayOrientation orientation)
        {
            switch (orientation)
            {
                case DisplayOrientation.LandscapeLeft:
                    return UIKit.UIInterfaceOrientation.LandscapeLeft;
                case DisplayOrientation.PortraitFlipped:
                case DisplayOrientation.Portrait:
                    return UIKit.UIInterfaceOrientation.Portrait;
                case DisplayOrientation.LandscapeRight:
                case DisplayOrientation.Default:
                default:
                    return UIKit.UIInterfaceOrientation.LandscapeRight;
            }
        }