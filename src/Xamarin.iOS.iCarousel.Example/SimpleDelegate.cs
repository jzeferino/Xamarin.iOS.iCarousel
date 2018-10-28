using System;
using UIKit;
using Xamarin.iOS.iCarouselBinding;

namespace Xamarin.iOS.iCarouselExample
{
    public partial class ViewController
    {
        public class SimpleDelegate : iCarouselDelegate
        {
            private readonly ViewController _viewController;

            public SimpleDelegate(ViewController vc)
            {
                _viewController = vc;
            }

            public override void DidSelectItemAtIndex(iCarousel carousel, nint index)
            {
                var alert = UIAlertController.Create("Clicked index:", index.ToString(), UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));

                _viewController.PresentViewController(alert, animated: true, completionHandler: null);
            }
        }
    }
}
