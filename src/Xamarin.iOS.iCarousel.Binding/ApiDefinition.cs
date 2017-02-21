using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using CoreAnimation;
using System.Runtime.InteropServices;

namespace Xamarin.iOS.iCarouselBinding
{
    // @interface iCarousel : UIView
    [BaseType(typeof(UIView))]
    interface iCarousel
    {
        // @property (nonatomic, unsafe_unretained) id<iCarouselDataSource> _Nullable dataSource __attribute__((iboutlet));
        [NullAllowed, Export("dataSource", ArgumentSemantic.Assign)]
        iCarouselDataSource DataSource { get; set; }

        [Wrap("WeakDelegate")]
        [NullAllowed]
        iCarouselDelegate Delegate { get; set; }

        // @property (nonatomic, unsafe_unretained) id<iCarouselDelegate> _Nullable delegate __attribute__((iboutlet));
        [NullAllowed, Export("delegate", ArgumentSemantic.Assign)]
        NSObject WeakDelegate { get; set; }

        // @property (assign, nonatomic) iCarouselType type;
        [Export("type", ArgumentSemantic.Assign)]
        iCarouselType Type { get; set; }

        // @property (assign, nonatomic) CGFloat perspective;
        [Export("perspective")]
        nfloat Perspective { get; set; }

        // @property (assign, nonatomic) CGFloat decelerationRate;
        [Export("decelerationRate")]
        nfloat DecelerationRate { get; set; }

        // @property (assign, nonatomic) CGFloat scrollSpeed;
        [Export("scrollSpeed")]
        nfloat ScrollSpeed { get; set; }

        // @property (assign, nonatomic) CGFloat bounceDistance;
        [Export("bounceDistance")]
        nfloat BounceDistance { get; set; }

        // @property (getter = isScrollEnabled, assign, nonatomic) BOOL scrollEnabled;
        [Export("scrollEnabled")]
        bool ScrollEnabled { [Bind("isScrollEnabled")] get; set; }

        // @property (getter = isPagingEnabled, assign, nonatomic) BOOL pagingEnabled;
        [Export("pagingEnabled")]
        bool PagingEnabled { [Bind("isPagingEnabled")] get; set; }

        // @property (getter = isVertical, assign, nonatomic) BOOL vertical;
        [Export("vertical")]
        bool Vertical { [Bind("isVertical")] get; set; }

        // @property (readonly, getter = isWrapEnabled, nonatomic) BOOL wrapEnabled;
        [Export("wrapEnabled")]
        bool WrapEnabled { [Bind("isWrapEnabled")] get; }

        // @property (assign, nonatomic) BOOL bounces;
        [Export("bounces")]
        bool Bounces { get; set; }

        // @property (assign, nonatomic) CGFloat scrollOffset;
        [Export("scrollOffset")]
        nfloat ScrollOffset { get; set; }

        // @property (readonly, nonatomic) CGFloat offsetMultiplier;
        [Export("offsetMultiplier")]
        nfloat OffsetMultiplier { get; }

        // @property (assign, nonatomic) CGSize contentOffset;
        [Export("contentOffset", ArgumentSemantic.Assign)]
        CGSize ContentOffset { get; set; }

        // @property (assign, nonatomic) CGSize viewpointOffset;
        [Export("viewpointOffset", ArgumentSemantic.Assign)]
        CGSize ViewpointOffset { get; set; }

        // @property (readonly, nonatomic) NSInteger numberOfItems;
        [Export("numberOfItems")]
        nint NumberOfItems { get; }

        // @property (readonly, nonatomic) NSInteger numberOfPlaceholders;
        [Export("numberOfPlaceholders")]
        nint NumberOfPlaceholders { get; }

        // @property (assign, nonatomic) NSInteger currentItemIndex;
        [Export("currentItemIndex")]
        nint CurrentItemIndex { get; set; }

        // @property (readonly, nonatomic, strong) UIView * _Nullable currentItemView;
        [NullAllowed, Export("currentItemView", ArgumentSemantic.Strong)]
        UIView CurrentItemView { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull indexesForVisibleItems;
        [Export("indexesForVisibleItems", ArgumentSemantic.Strong)]
        NSNumber[] IndexesForVisibleItems { get; }

        // @property (readonly, nonatomic) NSInteger numberOfVisibleItems;
        [Export("numberOfVisibleItems")]
        nint NumberOfVisibleItems { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull visibleItemViews;
        [Export("visibleItemViews", ArgumentSemantic.Strong)]
        NSNumber[] VisibleItemViews { get; }

        // @property (readonly, nonatomic) CGFloat itemWidth;
        [Export("itemWidth")]
        nfloat ItemWidth { get; }

        // @property (readonly, nonatomic, strong) UIView * _Nonnull contentView;
        [Export("contentView", ArgumentSemantic.Strong)]
        UIView ContentView { get; }

        // @property (readonly, nonatomic) CGFloat toggle;
        [Export("toggle")]
        nfloat Toggle { get; }

        // @property (assign, nonatomic) CGFloat autoscroll;
        [Export("autoscroll")]
        nfloat Autoscroll { get; set; }

        // @property (assign, nonatomic) BOOL stopAtItemBoundary;
        [Export("stopAtItemBoundary")]
        bool StopAtItemBoundary { get; set; }

        // @property (assign, nonatomic) BOOL scrollToItemBoundary;
        [Export("scrollToItemBoundary")]
        bool ScrollToItemBoundary { get; set; }

        // @property (assign, nonatomic) BOOL ignorePerpendicularSwipes;
        [Export("ignorePerpendicularSwipes")]
        bool IgnorePerpendicularSwipes { get; set; }

        // @property (assign, nonatomic) BOOL centerItemWhenSelected;
        [Export("centerItemWhenSelected")]
        bool CenterItemWhenSelected { get; set; }

        // @property (readonly, getter = isDragging, nonatomic) BOOL dragging;
        [Export("dragging")]
        bool Dragging { [Bind("isDragging")] get; }

        // @property (readonly, getter = isDecelerating, nonatomic) BOOL decelerating;
        [Export("decelerating")]
        bool Decelerating { [Bind("isDecelerating")] get; }

        // @property (readonly, getter = isScrolling, nonatomic) BOOL scrolling;
        [Export("scrolling")]
        bool Scrolling { [Bind("isScrolling")] get; }

        // -(void)scrollByOffset:(CGFloat)offset duration:(NSTimeInterval)duration;
        [Export("scrollByOffset:duration:")]
        void ScrollByOffset(nfloat offset, double duration);

        // -(void)scrollToOffset:(CGFloat)offset duration:(NSTimeInterval)duration;
        [Export("scrollToOffset:duration:")]
        void ScrollToOffset(nfloat offset, double duration);

        // -(void)scrollByNumberOfItems:(NSInteger)itemCount duration:(NSTimeInterval)duration;
        [Export("scrollByNumberOfItems:duration:")]
        void ScrollByNumberOfItems(nint itemCount, double duration);

        // -(void)scrollToItemAtIndex:(NSInteger)index duration:(NSTimeInterval)duration;
        [Export("scrollToItemAtIndex:duration:")]
        void ScrollToItemAtIndex(nint index, double duration);

        // -(void)scrollToItemAtIndex:(NSInteger)index animated:(BOOL)animated;
        [Export("scrollToItemAtIndex:animated:")]
        void ScrollToItemAtIndex(nint index, bool animated);

        // -(UIView * _Nullable)itemViewAtIndex:(NSInteger)index;
        [Export("itemViewAtIndex:")]
        [return: NullAllowed]
        UIView ItemViewAtIndex(nint index);

        // -(NSInteger)indexOfItemView:(UIView * _Nonnull)view;
        [Export("indexOfItemView:")]
        nint IndexOfItemView(UIView view);

        // -(NSInteger)indexOfItemViewOrSubview:(UIView * _Nonnull)view;
        [Export("indexOfItemViewOrSubview:")]
        nint IndexOfItemViewOrSubview(UIView view);

        // -(CGFloat)offsetForItemAtIndex:(NSInteger)index;
        [Export("offsetForItemAtIndex:")]
        nfloat OffsetForItemAtIndex(nint index);

        // -(UIView * _Nullable)itemViewAtPoint:(CGPoint)point;
        [Export("itemViewAtPoint:")]
        [return: NullAllowed]
        UIView ItemViewAtPoint(CGPoint point);

        // -(void)removeItemAtIndex:(NSInteger)index animated:(BOOL)animated;
        [Export("removeItemAtIndex:animated:")]
        void RemoveItemAtIndex(nint index, bool animated);

        // -(void)insertItemAtIndex:(NSInteger)index animated:(BOOL)animated;
        [Export("insertItemAtIndex:animated:")]
        void InsertItemAtIndex(nint index, bool animated);

        // -(void)reloadItemAtIndex:(NSInteger)index animated:(BOOL)animated;
        [Export("reloadItemAtIndex:animated:")]
        void ReloadItemAtIndex(nint index, bool animated);

        // -(void)reloadData;
        [Export("reloadData")]
        void ReloadData();
    }

    // @protocol iCarouselDataSource <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface iCarouselDataSource
    {
        // @required -(NSInteger)numberOfItemsInCarousel:(iCarousel * _Nonnull)carousel;
        [Abstract]
        [Export("numberOfItemsInCarousel:")]
        nint NumberOfItemsInCarousel(iCarousel carousel);

        // @required -(UIView * _Nonnull)carousel:(iCarousel * _Nonnull)carousel viewForItemAtIndex:(NSInteger)index reusingView:(UIView * _Nullable)view;
        [Abstract]
        [Export("carousel:viewForItemAtIndex:reusingView:")]
        UIView ViewForItemAtIndex(iCarousel carousel, nint index, [NullAllowed] UIView view);

        // @optional -(NSInteger)numberOfPlaceholdersInCarousel:(iCarousel * _Nonnull)carousel;
        [Export("numberOfPlaceholdersInCarousel:")]
        nint NumberOfPlaceholdersInCarousel(iCarousel carousel);

        // @optional -(UIView * _Nonnull)carousel:(iCarousel * _Nonnull)carousel placeholderViewAtIndex:(NSInteger)index reusingView:(UIView * _Nullable)view;
        [Export("carousel:placeholderViewAtIndex:reusingView:")]
        UIView PlaceholderViewAtIndex(iCarousel carousel, nint index, [NullAllowed] UIView view);
    }

    // @protocol iCarouselDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface iCarouselDelegate
    {
        // @optional -(void)carouselWillBeginScrollingAnimation:(iCarousel * _Nonnull)carousel;
        [Export("carouselWillBeginScrollingAnimation:")]
        void CarouselWillBeginScrollingAnimation(iCarousel carousel);

        // @optional -(void)carouselDidEndScrollingAnimation:(iCarousel * _Nonnull)carousel;
        [Export("carouselDidEndScrollingAnimation:")]
        void CarouselDidEndScrollingAnimation(iCarousel carousel);

        // @optional -(void)carouselDidScroll:(iCarousel * _Nonnull)carousel;
        [Export("carouselDidScroll:")]
        void CarouselDidScroll(iCarousel carousel);

        // @optional -(void)carouselCurrentItemIndexDidChange:(iCarousel * _Nonnull)carousel;
        [Export("carouselCurrentItemIndexDidChange:")]
        void CarouselCurrentItemIndexDidChange(iCarousel carousel);

        // @optional -(void)carouselWillBeginDragging:(iCarousel * _Nonnull)carousel;
        [Export("carouselWillBeginDragging:")]
        void CarouselWillBeginDragging(iCarousel carousel);

        // @optional -(void)carouselDidEndDragging:(iCarousel * _Nonnull)carousel willDecelerate:(BOOL)decelerate;
        [Export("carouselDidEndDragging:willDecelerate:")]
        void CarouselDidEndDragging(iCarousel carousel, bool decelerate);

        // @optional -(void)carouselWillBeginDecelerating:(iCarousel * _Nonnull)carousel;
        [Export("carouselWillBeginDecelerating:")]
        void CarouselWillBeginDecelerating(iCarousel carousel);

        // @optional -(void)carouselDidEndDecelerating:(iCarousel * _Nonnull)carousel;
        [Export("carouselDidEndDecelerating:")]
        void CarouselDidEndDecelerating(iCarousel carousel);

        // @optional -(BOOL)carousel:(iCarousel * _Nonnull)carousel shouldSelectItemAtIndex:(NSInteger)index;
        [Export("carousel:shouldSelectItemAtIndex:")]
        bool ShouldSelectItemAtIndex(iCarousel carousel, nint index);

        // @optional -(void)carousel:(iCarousel * _Nonnull)carousel didSelectItemAtIndex:(NSInteger)index;
        [Export("carousel:didSelectItemAtIndex:")]
        void DidSelectItemAtIndex(iCarousel carousel, nint index);

        // @optional -(CGFloat)carouselItemWidth:(iCarousel * _Nonnull)carousel;
        [Export("carouselItemWidth:")]
        nfloat CarouselItemWidth(iCarousel carousel);

        // @optional -(CATransform3D)carousel:(iCarousel * _Nonnull)carousel itemTransformForOffset:(CGFloat)offset baseTransform:(CATransform3D)transform;
        [Export("carousel:itemTransformForOffset:baseTransform:")]
        CATransform3D ItemTransformForOffset(iCarousel carousel, nfloat offset, CATransform3D transform);

        // @optional -(CGFloat)carousel:(iCarousel * _Nonnull)carousel valueForOption:(iCarouselOption)option withDefault:(CGFloat)value;
        [Export("carousel:valueForOption:withDefault:")]
        nfloat ValueForOption(iCarousel carousel, iCarouselOption option, nfloat value);
    }
}
