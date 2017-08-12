using System;
using CoreAnimation;

namespace Xamarin.iOS.iCarouselBinding
{
    public class CarouselDelegate : iCarouselDelegate
    {
        public override void CarouselCurrentItemIndexDidChange(iCarousel carousel)
        {
        }

        public override void CarouselDidEndDecelerating(iCarousel carousel)
        {
        }

        public override void CarouselDidEndDragging(iCarousel carousel, bool decelerate)
        {
        }

        public override void CarouselDidEndScrollingAnimation(iCarousel carousel)
        {
        }

        public override void CarouselDidScroll(iCarousel carousel)
        {
        }

        public override nfloat CarouselItemWidth(iCarousel carousel)
        {
            return 0;
        }

        public override void CarouselWillBeginDecelerating(iCarousel carousel)
        {
        }

        public override void CarouselWillBeginDragging(iCarousel carousel)
        {
        }

        public override void CarouselWillBeginScrollingAnimation(iCarousel carousel)
        {
        }

        public override void DidSelectItemAtIndex(iCarousel carousel, nint index)
        {
        }

        public override CATransform3D ItemTransformForOffset(iCarousel carousel, nfloat offset, CATransform3D transform)
        {
            return transform;
        }

        public override bool ShouldSelectItemAtIndex(iCarousel carousel, nint index)
        {
            return true;
        }

        public override nfloat ValueForOption(iCarousel carousel, iCarouselOption option, nfloat value)
        {
            return value;
        }
    }
}
