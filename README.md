[![Build status](https://ci.appveyor.com/api/projects/status/rk8n3fe0c6udgurg?svg=true)](https://ci.appveyor.com/project/jzeferino/xamarin-ios-icarousel/)   [![NuGet](https://img.shields.io/nuget/v/Xamarin.iOS.iCarousel.svg?label=NuGet)](https://www.nuget.org/packages/Xamarin.iOS.iCarousel/)

Xamarin.iOS.iCarousel
===================

This is a Xamarin Android Binding for the [iCarousel](https://github.com/nicklockwood/iCarousel).

A simple, highly customisable, data-driven 3D carousel for iOS.

## Demo
<p align="center">
  <img src="https://github.com/jzeferino/Xamarin.iOS.iCarousel/blob/master/art/icarousel.gif?raw=true"/>
</p>

## Usage
(see the [sample](https://github.com/jzeferino/Xamarin.iOS.iCarousel/tree/master/src/Xamarin.iOS.iCarousel.Example) project for a detailed working example)

### Step 1

Instal NuGet [package](https://www.nuget.org/packages/Xamarin.iOS.iCarousel/).

### Step 2

Add the iCarousel to your layout:
```c#
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
```

### Please check the original [README](https://github.com/nicklockwood/iCarousel/blob/master/README.md) for more information.
 
### License
[MIT Licence](LICENSE) 
