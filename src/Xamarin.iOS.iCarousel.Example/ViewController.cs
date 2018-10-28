using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FFImageLoading;
using UIKit;
using Xamarin.iOS.iCarouselBinding;
using Xamarin.iOS.iCarouselExample.Extensions;

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
                ContentMode = UIViewContentMode.ScaleAspectFit,
                Type = iCarouselType.Rotary,
                Frame = View.Frame,
                CenterItemWhenSelected = true,
                PagingEnabled = true,
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
                    var imgView = new UIImageView(new RectangleF(0, 0, (float)carousel.Frame.Height, (float)carousel.Frame.Width))
                    {
                        BackgroundColor = UIColor.Orange
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

                // NOT working
                /*ImageService.Instance
                  .LoadUrl("https://picsum.photos/1000/2000" + "?=" + DateTime.Now.Ticks)
                  .Into((view as UIImageView));*/

                // Working
                (view as UIImageView).LoadImageAsync("https://picsum.photos/1000/2000" + "?=" + DateTime.Now.Ticks);
                return view;
            }
        }
    }
}
