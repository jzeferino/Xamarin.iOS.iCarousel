using System;
using Foundation;
using ImageIO;
using UIKit;

namespace Xamarin.iOS.iCarouselExample.Extensions
{
    public static class UIImageViewExtensions
    {
        public static void LoadImageAsync(this UIImageView image, string url, string placeHolder = null, Action completed = null)
        {
            if (placeHolder != null)
            {
                image.Image = UIImage.FromBundle(placeHolder);
            }

            NSUrlSession.SharedSession.CreateDataTask(new NSUrlRequest(new NSUrl(url)), (data, response, error) =>
            {
                if (error == null && response != null)
                {
                    image.InvokeOnMainThread(() =>
                    {
                        UIView.Transition(image, 0.5, UIViewAnimationOptions.TransitionCrossDissolve, () => image.Image = UIImage.LoadFromData(data), completed);
                    });
                }
            }).Resume();
        }
    }
}
