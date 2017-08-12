using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using UIKit;
using Xamarin.iOS.iCarouselBinding;

namespace Xamarin.iOS.iCarouselExample
{
    public partial class ViewController : UIViewController
    {
        protected ViewController(IntPtr handle) : base(handle)
        {
        }

        private List<int> items;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            items = Enumerable.Range(1, 100).ToList();

            // Setup iCarousel view
            var carousel = new iCarousel
            {
                Bounds = View.Bounds,
                ContentMode = UIViewContentMode.Center,
                Type = iCarouselType.CoverFlow2,
                Frame = View.Frame,
                CenterItemWhenSelected = true,
                DataSource = new SimpleDataSource(items),
                Delegate = new SimpleDelegate(this)
            };

            View.AddSubview(carousel);
            ViewDidLayoutSubviews();
        }

        public class SimpleDataSource : iCarouselDataSource
        {
            private readonly List<int> _data;

            public SimpleDataSource(List<int> data)
            {
                _data = data;
            }

            public override nint NumberOfItemsInCarousel(iCarousel carousel) => _data.Count;

            public override UIView ViewForItemAtIndex(iCarousel carousel, nint index, UIView view)
            {
                UILabel label;

                // create new view if no view is available for recycling
                if (view == null)
                {
                    var imgView = new UIImageView(new RectangleF(0, 200, 200, 200))
                    {
                        BackgroundColor = UIColor.Orange,
                        ContentMode = UIViewContentMode.Center
                    };

                    label = new UILabel(imgView.Bounds)
                    {
                        BackgroundColor = UIColor.Clear,
                        TextAlignment = UITextAlignment.Center,
                        Tag = 1
                    };
                    imgView.AddSubview(label);
                    view = imgView;
                }
                else
                {
                    // get a reference to the label in the recycled view
                    label = (UILabel)view.ViewWithTag(1);
                }

                label.Text = _data[(int)index].ToString();

                return view;
            }
        }

        public class SimpleDelegate : CarouselDelegate
        {
            private readonly ViewController _viewController;

            public SimpleDelegate(ViewController vc)
            {
                _viewController = vc;
            }

            public override void DidSelectItemAtIndex(iCarousel carousel, nint index)
            {
                base.DidSelectItemAtIndex(carousel, index);
                var alert = UIAlertController.Create("Clicked index:", index.ToString(), UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));

                _viewController.PresentViewController(alert, animated: true, completionHandler: null);
            }

            public override nfloat ValueForOption(iCarousel carousel, iCarouselOption option, nfloat value)
            {
                return base.ValueForOption(carousel, option, value);
            }
        }
    }
}
