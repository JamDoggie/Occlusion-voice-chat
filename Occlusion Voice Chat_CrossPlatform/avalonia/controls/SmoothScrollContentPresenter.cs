using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Animation = Avalonia.Animation.Animation;
using Clock = Avalonia.Animation.Clock;
using Avalonia.Animation.Easings;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using Avalonia.VisualTree;
using Avalonia.Threading;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Layout;

#nullable enable

namespace Occlusion_Voice_Chat_CrossPlatform.avalonia.controls
{
    public class SmoothScrollContentPresenter : ContentPresenter, IPresenter, IScrollable, IScrollAnchorProvider
    {
        private const double EdgeDetectionTolerance = 0.1;

        /// <summary>
        /// Defines the <see cref="CanHorizontallyScroll"/> property.
        /// </summary>
        public static readonly DirectProperty<SmoothScrollContentPresenter, bool> CanHorizontallyScrollProperty =
            AvaloniaProperty.RegisterDirect<SmoothScrollContentPresenter, bool>(
                nameof(CanHorizontallyScroll),
                o => o.CanHorizontallyScroll,
                (o, v) => o.CanHorizontallyScroll = v);

        /// <summary>
        /// Defines the <see cref="CanVerticallyScroll"/> property.
        /// </summary>
        public static readonly DirectProperty<SmoothScrollContentPresenter, bool> CanVerticallyScrollProperty =
            AvaloniaProperty.RegisterDirect<SmoothScrollContentPresenter, bool>(
                nameof(CanVerticallyScroll),
                o => o.CanVerticallyScroll,
                (o, v) => o.CanVerticallyScroll = v);

        /// <summary>
        /// Defines the <see cref="Extent"/> property.
        /// </summary>
        public static readonly DirectProperty<SmoothScrollContentPresenter, Size> ExtentProperty =
            SmoothScrollViewer.ExtentProperty.AddOwner<SmoothScrollContentPresenter>(
                o => o.Extent,
                (o, v) => o.Extent = v);

        /// <summary>
        /// Defines the <see cref="Offset"/> property.
        /// </summary>
        public static readonly DirectProperty<SmoothScrollContentPresenter, Vector> OffsetProperty =
            SmoothScrollViewer.OffsetProperty.AddOwner<SmoothScrollContentPresenter>(
                o => o.Offset,
                (o, v) => o.Offset = v);

        /// <summary>
        /// Defines the <see cref="AnimationOffset"/> property.
        /// </summary>
        public static readonly StyledProperty<Vector> AnimationOffsetProperty =
            AvaloniaProperty.Register<SmoothScrollContentPresenter, Vector>(nameof(AnimationOffset));

        /*
        /// <summary>
        /// Defines the <see cref="SmoothScrollEasing"/> property.
        /// </summary>
        public static readonly StyledProperty<Easing> SmoothScrollEasingProperty =
            AvaloniaProperty.Register<SmoothScrollViewer, Easing>(nameof(SmoothScrollEasing));
        /*public static readonly DirectProperty<SmoothScrollContentPresenter, Easing> SmoothScrollEasingProperty =
            AvaloniaProperty.RegisterDirect<SmoothScrollContentPresenter, Easing>(
                nameof(SmoothScrollEasing),
                o => o.SmoothScrollEasing,
                (o, v) => o.SmoothScrollEasing = v);*/

        /*
        /// <summary>
        /// Defines the <see cref="SmoothScrollDuration"/> property.
        /// </summary>
        public static readonly StyledProperty<TimeSpan> SmoothScrollDurationProperty =
            AvaloniaProperty.Register<SmoothScrollViewer, TimeSpan>(nameof(SmoothScrollDuration));
        /*public static readonly DirectProperty<SmoothScrollContentPresenter, TimeSpan> SmoothScrollDurationProperty =
            AvaloniaProperty.RegisterDirect<SmoothScrollContentPresenter, TimeSpan>(
                nameof(SmoothScrollDuration),
                o => o.SmoothScrollDuration,
                (o, v) => o.SmoothScrollDuration = v);*/

        /// <summary>
        /// Defines the <see cref="Viewport"/> property.
        /// </summary>
        public static readonly DirectProperty<SmoothScrollContentPresenter, Size> ViewportProperty =
            SmoothScrollViewer.ViewportProperty.AddOwner<SmoothScrollContentPresenter>(
                o => o.Viewport,
                (o, v) => o.Viewport = v);

        // Arbitrary chosen value, probably need to ask ILogicalScrollable
        private const int LogicalScrollItemSize = 50;

        private bool _canHorizontallyScroll;
        private bool _canVerticallyScroll;
        private bool _arranging;
        private Size _extent;
        private Vector _offset;
        //private Easing _smoothScrollEasing = new BounceEaseInOut();
        //private TimeSpan _smoothScrollDuration = TimeSpan.FromMilliseconds(0);
        //private bool _usesSmoothScrolling = true;
        private bool _shouldAnimateOffset = false;
        private DispatcherTimer _smoothScrollTimer; //Timer(1);
        private bool _smoothScrollTimerStarted = false;
        private double _animStartOffsetX = 0;
        private double _animStartOffsetY = 0;
        private double _offsetX = 0;
        private double _offsetY = 0;
        private double _animDuration = 0;
        private double _animTimeRemaining = 0;

        private IEasing _currentEasing;
        private IDisposable? _logicalScrollSubscription;
        private Size _viewport;
        private Dictionary<int, Vector>? _activeLogicalGestureScrolls;
        private List<IControl>? _anchorCandidates;
        private IControl? _anchorElement;
        private Rect _anchorElementBounds;
        private bool _isAnchorElementDirty;

        /// <summary>
        /// Initializes static members of the <see cref="SmoothScrollContentPresenter"/> class.
        /// </summary>
        static SmoothScrollContentPresenter()
        {
            ClipToBoundsProperty.OverrideDefaultValue(typeof(SmoothScrollContentPresenter), true);
            ChildProperty.Changed.AddClassHandler<SmoothScrollContentPresenter>((x, e) => x.ChildChanged(e));
            OffsetProperty.Changed.AddClassHandler<SmoothScrollContentPresenter>((x, e) => x.OffsetChanged(e));

            AffectsArrange<SmoothScrollContentPresenter>(AnimationOffsetProperty);

            //SmoothScrollEasingProperty.Changed.AddClassHandler<SmoothScrollContentPresenter>((x, e) => x.SmoothScrollPropertiesChanged());
            //SmoothScrollDurationProperty.Changed.AddClassHandler<SmoothScrollContentPresenter>((x, e) => x.SmoothScrollPropertiesChanged());
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SmoothScrollContentPresenter"/> class.
        /// </summary>
        public SmoothScrollContentPresenter()
        {
            AddHandler(RequestBringIntoViewEvent, BringIntoViewRequested);
            AddHandler(Gestures.ScrollGestureEvent, OnScrollGesture);

            this.GetObservable(ChildProperty).Subscribe(UpdateScrollableSubscription);

            _smoothScrollTimer = new DispatcherTimer(TimeSpan.FromMilliseconds(1), DispatcherPriority.Render, SmoothScrollTimer_Elapsed);
            //SmoothScrollPropertiesChanged();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the content can be scrolled horizontally.
        /// </summary>
        public bool CanHorizontallyScroll
        {
            get { return _canHorizontallyScroll; }
            set { SetAndRaise(CanHorizontallyScrollProperty, ref _canHorizontallyScroll, value); }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the content can be scrolled horizontally.
        /// </summary>
        public bool CanVerticallyScroll
        {
            get { return _canVerticallyScroll; }
            set { SetAndRaise(CanVerticallyScrollProperty, ref _canVerticallyScroll, value); }
        }

        /// <summary>
        /// Gets the extent of the scrollable content.
        /// </summary>
        public Size Extent
        {
            get { return _extent; }
            private set { SetAndRaise(ExtentProperty, ref _extent, value); }
        }

        /// <summary>
        /// Gets or sets the current logical scroll offset.
        /// </summary>
        public Vector Offset
        {
            get { return _offset; }
            set { SetAndRaise(OffsetProperty, ref _offset, SmoothScrollViewer.CoerceOffset(Extent, Viewport, value)); }
        }

        /// <summary>
        /// Gets or sets the current visible scroll offset.
        /// </summary>
        public Vector AnimationOffset
        {
            get => GetValue(AnimationOffsetProperty);
            set => SetValue(AnimationOffsetProperty, value);
        }

        /*
        /// <summary>
        /// Gets or sets the easing function to be used when scrolling.
        /// </summary>
        public Easing SmoothScrollEasing
        {
            get => GetValue(SmoothScrollEasingProperty);
            set => SetValue(SmoothScrollEasingProperty, value);
        }
        /// <summary>
        /// Gets or sets the current smooth-scroll duration.
        /// </summary>
        public TimeSpan SmoothScrollDuration
        {
            get => GetValue(SmoothScrollDurationProperty);
            set => SetValue(SmoothScrollDurationProperty, value);
        }*/


        private bool ShouldUseSmoothScrolling(out IEasing easing, out TimeSpan duration)
        {
            if (TemplatedParent is SmoothScrollViewer scrollV)
            {
                easing = scrollV.SmoothScrollEasing;
                duration = scrollV.SmoothScrollDuration;
                return (easing != null) && (duration != null) && (duration.TotalMilliseconds > 0);
            }
            else
            {
                easing = null;
                duration = TimeSpan.Zero;
                return false;
            }
        }
        private bool UsesSmoothScrolling
        {
            get => ShouldUseSmoothScrolling(out IEasing _, out TimeSpan __);
        }

        private Vector _currentFromOffset
        {
            get
            {
                if (UsesSmoothScrolling) //_usesSmoothScrolling)
                    return AnimationOffset;
                else
                    return Offset;
            }
        }

        /// <summary>
        /// Gets the size of the viewport on the scrollable content.
        /// </summary>
        public Size Viewport
        {
            get { return _viewport; }
            private set { SetAndRaise(ViewportProperty, ref _viewport, value); }
        }

        /// <inheritdoc/>
        IControl? IScrollAnchorProvider.CurrentAnchor
        {
            get
            {
                EnsureAnchorElementSelection();
                return _anchorElement;
            }
        }

        /// <summary>
        /// Attempts to bring a portion of the target visual into view by scrolling the content.
        /// </summary>
        /// <param name="target">The target visual.</param>
        /// <param name="targetRect">The portion of the target visual to bring into view.</param>
        /// <returns>True if the scroll offset was changed; otherwise false.</returns>
        public bool BringDescendantIntoView(IVisual target, Rect targetRect)
        {
            if (Child?.IsEffectivelyVisible != true)
            {
                return false;
            }

            var scrollable = Child as ILogicalScrollable;
            var control = target as IControl;

            if (scrollable?.IsLogicalScrollEnabled == true && control != null)
            {
                return scrollable.BringIntoView(control, targetRect);
            }

            var transform = target.TransformToVisual(Child);

            if (transform == null)
            {
                return false;
            }

            var rect = targetRect.TransformToAABB(transform.Value);
            var offset = _currentFromOffset;
            var result = false;

            if (rect.Bottom > offset.Y + Viewport.Height)
            {
                offset = offset.WithY((rect.Bottom - Viewport.Height) + Child.Margin.Top);
                result = true;
            }

            if (rect.Y < offset.Y)
            {
                offset = offset.WithY(rect.Y);
                result = true;
            }

            if (rect.Right > offset.X + Viewport.Width)
            {
                offset = offset.WithX((rect.Right - Viewport.Width) + Child.Margin.Left);
                result = true;
            }

            if (rect.X < offset.X)
            {
                offset = offset.WithX(rect.X);
                result = true;
            }

            if (result)
            {
                Offset = offset;
            }

            return result;
        }

        /// <inheritdoc/>
        void IScrollAnchorProvider.RegisterAnchorCandidate(IControl element)
        {
            if (!this.IsVisualAncestorOf(element))
            {
                throw new InvalidOperationException(
                    "An anchor control must be a visual descendent of the SmoothScrollContentPresenter.");
            }

            _anchorCandidates ??= new List<IControl>();
            _anchorCandidates.Add(element);
            _isAnchorElementDirty = true;
        }

        /// <inheritdoc/>
        void IScrollAnchorProvider.UnregisterAnchorCandidate(IControl element)
        {
            _anchorCandidates?.Remove(element);
            _isAnchorElementDirty = true;

            if (_anchorElement == element)
            {
                _anchorElement = null;
            }
        }

        /// <inheritdoc/>
        protected override Size MeasureOverride(Size availableSize)
        {
            if (_logicalScrollSubscription != null || Child == null)
            {
                return base.MeasureOverride(availableSize);
            }

            var constraint = new Size(
                CanHorizontallyScroll ? double.PositiveInfinity : availableSize.Width,
                CanVerticallyScroll ? double.PositiveInfinity : availableSize.Height);

            Child.Measure(constraint);
            return Child.DesiredSize.Constrain(availableSize);
        }

        /// <inheritdoc/>
        protected override Size ArrangeOverride(Size finalSize)
        {
            if (_logicalScrollSubscription != null || Child == null)
            {
                return base.ArrangeOverride(finalSize);
            }

            return ArrangeWithAnchoring(finalSize);
        }

        private Size ArrangeWithAnchoring(Size finalSize)
        {
            var size = new Size(
                CanHorizontallyScroll ? Math.Max(Child.DesiredSize.Width, finalSize.Width) : finalSize.Width,
                CanVerticallyScroll ? Math.Max(Child.DesiredSize.Height, finalSize.Height) : finalSize.Height);

            Vector TrackAnchor()
            {
                // If we have an anchor and its position relative to Child has changed during the
                // arrange then that change wasn't just due to scrolling (as scrolling doesn't adjust
                // relative positions within Child).
                if (_anchorElement != null &&
                    TranslateBounds(_anchorElement, Child, out var updatedBounds) &&
                    updatedBounds.Position != _anchorElementBounds.Position)
                {
                    var offset = updatedBounds.Position - _anchorElementBounds.Position;
                    return offset;
                }

                return default;
            }

            var currentFromOffset = _currentFromOffset;
            var isAnchoring = currentFromOffset.X >= EdgeDetectionTolerance || currentFromOffset.Y >= EdgeDetectionTolerance;

            if (isAnchoring)
            {
                // Calculate the new anchor element if necessary.
                EnsureAnchorElementSelection();

                // Do the arrange.
                ArrangeOverrideImpl(size, -currentFromOffset);

                // If the anchor moved during the arrange, we need to adjust the offset and do another arrange.
                var anchorShift = TrackAnchor();

                if (anchorShift != default)
                {
                    var newOffset = currentFromOffset + anchorShift;
                    var newExtent = Extent;
                    var maxOffset = new Vector(Extent.Width - Viewport.Width, Extent.Height - Viewport.Height);

                    if (newOffset.X > maxOffset.X)
                    {
                        newExtent = newExtent.WithWidth(newOffset.X + Viewport.Width);
                    }

                    if (newOffset.Y > maxOffset.Y)
                    {
                        newExtent = newExtent.WithHeight(newOffset.Y + Viewport.Height);
                    }

                    Extent = newExtent;

                    try
                    {
                        _arranging = true;
                        Offset = newOffset;
                    }
                    finally
                    {
                        _arranging = false;
                    }

                    ArrangeOverrideImpl(size, -currentFromOffset);
                }
            }
            else
            {
                
                ArrangeOverrideImpl(size, -currentFromOffset);
            }

            Viewport = finalSize;
            Extent = Child.Bounds.Size.Inflate(Child.Margin);
            _isAnchorElementDirty = true;

            return finalSize;
        }

        internal Size ArrangeOverrideImpl(Size finalSize, Vector offset)
        {
            if (Child == null) return finalSize;

            var padding = Padding + BorderThickness;
            var horizontalContentAlignment = HorizontalContentAlignment;
            var verticalContentAlignment = VerticalContentAlignment;
            var useLayoutRounding = UseLayoutRounding;
            var availableSize = finalSize;
            var sizeForChild = availableSize;
            var scale = LayoutHelper.GetLayoutScale(this);
            var originX = offset.X;
            var originY = offset.Y;

            if (horizontalContentAlignment != HorizontalAlignment.Stretch)
            {
                sizeForChild = sizeForChild.WithWidth(Math.Min(sizeForChild.Width, DesiredSize.Width));
            }

            if (verticalContentAlignment != VerticalAlignment.Stretch)
            {
                sizeForChild = sizeForChild.WithHeight(Math.Min(sizeForChild.Height, DesiredSize.Height));
            }

            if (useLayoutRounding)
            {
                sizeForChild = LayoutHelper.RoundLayoutSize(sizeForChild, scale, scale);
                availableSize = LayoutHelper.RoundLayoutSize(availableSize, scale, scale);
            }

            switch (horizontalContentAlignment)
            {
                case HorizontalAlignment.Center:
                    originX += (availableSize.Width - sizeForChild.Width) / 2;
                    break;
                case HorizontalAlignment.Right:
                    originX += availableSize.Width - sizeForChild.Width;
                    break;
            }

            switch (verticalContentAlignment)
            {
                case VerticalAlignment.Center:
                    originY += (availableSize.Height - sizeForChild.Height) / 2;
                    break;
                case VerticalAlignment.Bottom:
                    originY += availableSize.Height - sizeForChild.Height;
                    break;
            }

            if (useLayoutRounding)
            {
                originX = LayoutHelper.RoundLayoutValue(originX, scale);
                originY = LayoutHelper.RoundLayoutValue(originY, scale);
            }

            var boundsForChild =
                new Rect(originX, originY, sizeForChild.Width, sizeForChild.Height).Deflate(padding);

            Child.Arrange(boundsForChild);

            return finalSize;
        }


        private void OnScrollGesture(object sender, ScrollGestureEventArgs e)
        {
            if (Extent.Height > Viewport.Height || Extent.Width > Viewport.Width)
            {
                var scrollable = Child as ILogicalScrollable;
                bool isLogical = scrollable?.IsLogicalScrollEnabled == true;

                double x = Offset.X;
                double y = Offset.Y;

                Vector delta = default;
                if (isLogical)
                    _activeLogicalGestureScrolls?.TryGetValue(e.Id, out delta);
                delta += e.Delta;

                if (Extent.Height > Viewport.Height)
                {
                    double dy;
                    if (isLogical)
                    {
                        var logicalUnits = delta.Y / LogicalScrollItemSize;
                        delta = delta.WithY(delta.Y - logicalUnits * LogicalScrollItemSize);
                        dy = logicalUnits * scrollable!.ScrollSize.Height;
                    }
                    else
                        dy = delta.Y;


                    y += dy;
                    y = Math.Max(y, 0);
                    y = Math.Min(y, Extent.Height - Viewport.Height);
                }

                if (Extent.Width > Viewport.Width)
                {
                    double dx;
                    if (isLogical)
                    {
                        var logicalUnits = delta.X / LogicalScrollItemSize;
                        delta = delta.WithX(delta.X - logicalUnits * LogicalScrollItemSize);
                        dx = logicalUnits * scrollable!.ScrollSize.Width;
                    }
                    else
                        dx = delta.X;
                    x += dx;
                    x = Math.Max(x, 0);
                    x = Math.Min(x, Extent.Width - Viewport.Width);
                }

                if (isLogical)
                {
                    if (_activeLogicalGestureScrolls == null)
                        _activeLogicalGestureScrolls = new Dictionary<int, Vector>();
                    _activeLogicalGestureScrolls[e.Id] = delta;
                }

                Offset = new Vector(x, y);
                e.Handled = true;
            }
        }

        private void OnScrollGestureEnded(object sender, ScrollGestureEndedEventArgs e)
            => _activeLogicalGestureScrolls?.Remove(e.Id);

        /// <inheritdoc/>
        protected override void OnPointerWheelChanged(PointerWheelEventArgs e)
        {
            if (Extent.Height > Viewport.Height || Extent.Width > Viewport.Width)
            {
                _shouldAnimateOffset = true;
                var scrollable = Child as ILogicalScrollable;
                bool isLogical = scrollable?.IsLogicalScrollEnabled == true;

                var currentFromOffset = Offset;
                double x = currentFromOffset.X;
                double y = currentFromOffset.Y;

                if (Extent.Height > Viewport.Height)
                {
                    double height = isLogical ? scrollable!.ScrollSize.Height : 50;
                    y += -e.Delta.Y * height;
                    y = Math.Max(y, 0);
                    y = Math.Min(y, Extent.Height - Viewport.Height);
                }

                if (Extent.Width > Viewport.Width)
                {
                    double width = isLogical ? scrollable!.ScrollSize.Width : 50;
                    x += -e.Delta.X * width;
                    x = Math.Max(x, 0);
                    x = Math.Min(x, Extent.Width - Viewport.Width);
                }

                Offset = new Vector(x, y);
                _shouldAnimateOffset = false;
                e.Handled = true;
            }
        }

        protected override void OnPropertyChanged<T>(AvaloniaPropertyChangedEventArgs<T> change)
        {
            if (change.Property == OffsetProperty && !_arranging)
            {
                InvalidateArrange();
            }

            base.OnPropertyChanged(change);
        }

        private void BringIntoViewRequested(object sender, RequestBringIntoViewEventArgs e)
        {
            e.Handled = BringDescendantIntoView(e.TargetObject, e.TargetRect);
        }

        private void ChildChanged(AvaloniaPropertyChangedEventArgs e)
        {
            UpdateScrollableSubscription((IControl?)e.NewValue);

            if (e.OldValue != null)
            {
                Offset = default(Vector);
            }
        }

        private void OffsetChanged(AvaloniaPropertyChangedEventArgs e)
        {
            var oldOffset = (Vector?)e.OldValue;
            var newOffset = (Vector?)e.NewValue;
            if (ShouldUseSmoothScrolling(out IEasing ease, out TimeSpan dur)) //TemplatedParent is SmoothScrollViewer scrollV) //_usesSmoothScrolling && _shouldAnimateOffset)
            {
                StartAnimatingOffset(oldOffset, newOffset, ease, dur); //scrollV.SmoothScrollDuration, scrollV.SmoothScrollEasing);
            }
            else
            {
                AnimationOffset = newOffset.GetValueOrDefault();
            }

            //string output = "SmoothScrollDuration: " + SmoothScrollDuration + "\n\tSmoothScrollEasing: " + SmoothScrollEasing + "\nTemplatedParent.SmoothScrollDuration: ";
            /*if (TemplatedParent != null)
                Console.WriteLine((TemplatedParent as SmoothScrollViewer).SmoothScrollDuration + "\n\tTemplatedParent.SmoothScrollEasing: " + (TemplatedParent as SmoothScrollViewer).SmoothScrollEasing);
            else
                Console.WriteLine("No parent!");*/
        }

        /*
        DONE: Clicking on ScrollBar track teleports, rather than moving smoothly
        TODO: ScrollBar thumb should move smoothly when scrolling via wheel
        */
        private void StartAnimatingOffset(Vector? oldOffset, Vector? newOffset, IEasing scrollEasing, TimeSpan scrollDuration)
        {
            var newOff = newOffset.GetValueOrDefault();

            if (_smoothScrollTimerStarted)
            {
                _animStartOffsetX = _offsetX;
                _animStartOffsetY = _offsetY;
            }

            _offsetX = newOff.X;
            _offsetY = newOff.Y;

            _animDuration = scrollDuration.TotalMilliseconds;
            _animTimeRemaining = _animDuration;


            if (!_smoothScrollTimerStarted)
            {
                var oldOff = oldOffset.GetValueOrDefault();

                _animStartOffsetX = oldOff.X;
                _animStartOffsetY = oldOff.Y;

                _currentEasing = scrollEasing;
                _smoothScrollTimerStarted = true;
                _smoothScrollTimer.Start();
            }
        }

        private void SmoothScrollTimer_Elapsed(object sender, EventArgs e)
        {
            double totalDistanceX = _offsetX - _animStartOffsetX;
            double totalDistanceY = _offsetY - _animStartOffsetY;

            double percentage = 1 - Math.Min(Math.Max(0, _animTimeRemaining / _animDuration), 1);
            double easedPercentage = _currentEasing.Ease(percentage);

            double currentX = _animStartOffsetX + (totalDistanceX * easedPercentage);
            double currentY = _animStartOffsetY + (totalDistanceY * easedPercentage);
            _animTimeRemaining--;
            //Console.WriteLine("_animTimeRemaining: " + _animTimeRemaining);
            //Console.WriteLine("percentage: " + percentage + "; \teasedPercentage: " + easedPercentage + "; \tcurrent: " + currentX + ", " + currentY + "\n\t\t");

            AnimationOffset = new Vector(currentX, currentY);

            if (_animTimeRemaining <= 0)
            {
                //Console.WriteLine("Stopping...");
                _smoothScrollTimerStarted = false;
                _smoothScrollTimer.Stop();
            }
        }

        /*private void SmoothScrollPropertiesChanged()
        {
            bool hasDuration = SmoothScrollDuration != null;
            _usesSmoothScrolling = (SmoothScrollEasing != null) && hasDuration && (SmoothScrollDuration.TotalMilliseconds > 0);
        }*/

        static string _animPseudoclass = ":animating";
        bool _hasAnimPseudoClass = false;
        void SetAnimPseudoclass(bool add)
        {
            if (_hasAnimPseudoClass != add)
            {
                if (add)
                    PseudoClasses.Add(_animPseudoclass);
                else
                    PseudoClasses.Remove(_animPseudoclass);
            }
        }

        private void UpdateScrollableSubscription(IControl? child)
        {
            var scrollable = child as ILogicalScrollable;

            _logicalScrollSubscription?.Dispose();
            _logicalScrollSubscription = null;

            if (scrollable != null)
            {
                scrollable.ScrollInvalidated += ScrollInvalidated;

                if (scrollable.IsLogicalScrollEnabled)
                {
                    _logicalScrollSubscription = new CompositeDisposable(
                        this.GetObservable(CanHorizontallyScrollProperty)
                            .Subscribe(x => scrollable.CanHorizontallyScroll = x),
                        this.GetObservable(CanVerticallyScrollProperty)
                            .Subscribe(x => scrollable.CanVerticallyScroll = x),
                        this.GetObservable(OffsetProperty)
                            .Skip(1).Subscribe(x => scrollable.Offset = x),
                        Disposable.Create(() => scrollable.ScrollInvalidated -= ScrollInvalidated));
                    UpdateFromScrollable(scrollable);
                }
            }
        }

        private void ScrollInvalidated(object sender, EventArgs e)
        {
            UpdateFromScrollable((ILogicalScrollable)sender);
        }

        private void UpdateFromScrollable(ILogicalScrollable scrollable)
        {
            var logicalScroll = _logicalScrollSubscription != null;

            if (logicalScroll != scrollable.IsLogicalScrollEnabled)
            {
                UpdateScrollableSubscription(Child);
                Offset = default(Vector);
                InvalidateMeasure();
            }
            else if (scrollable.IsLogicalScrollEnabled)
            {
                Viewport = scrollable.Viewport;
                Extent = scrollable.Extent;
                Offset = scrollable.Offset;
            }
        }

        private void EnsureAnchorElementSelection()
        {
            if (!_isAnchorElementDirty || _anchorCandidates is null)
            {
                return;
            }

            _anchorElement = null;
            _anchorElementBounds = default;
            _isAnchorElementDirty = false;

            var bestCandidate = default(IControl);
            var bestCandidateDistance = double.MaxValue;

            // Find the anchor candidate that is scrolled closest to the top-left of this
            // SmoothScrollContentPresenter.
            foreach (var element in _anchorCandidates)
            {
                if (element.IsVisible && GetViewportBounds(element, out var bounds))
                {
                    var distance = (Vector)bounds.Position;
                    var candidateDistance = Math.Abs(distance.Length);

                    if (candidateDistance < bestCandidateDistance)
                    {
                        bestCandidate = element;
                        bestCandidateDistance = candidateDistance;
                    }
                }
            }

            if (bestCandidate != null)
            {
                // We have a candidate, calculate its bounds relative to Child. Because these
                // bounds aren't relative to the SmoothScrollContentPresenter itself, if they change
                // then we know it wasn't just due to scrolling.
                var unscrolledBounds = TranslateBounds(bestCandidate, Child);
                _anchorElement = bestCandidate;
                _anchorElementBounds = unscrolledBounds;
            }
        }

        private bool GetViewportBounds(IControl element, out Rect bounds)
        {
            if (TranslateBounds(element, Child, out var childBounds))
            {
                // We want the bounds relative to the new Offset, regardless of whether the child
                // control has actually been arranged to this offset yet, so translate first to the
                // child control and then apply Offset rather than translating directly to this
                // control.
                var thisBounds = new Rect(Bounds.Size);
                bounds = new Rect(childBounds.Position - _currentFromOffset, childBounds.Size);
                return bounds.Intersects(thisBounds);
            }

            bounds = default;
            return false;
        }

        private Rect TranslateBounds(IControl control, IControl to)
        {
            if (TranslateBounds(control, to, out var bounds))
            {
                return bounds;
            }

            throw new InvalidOperationException("The control's bounds could not be translated to the requested control.");
        }

        private bool TranslateBounds(IControl control, IControl to, out Rect bounds)
        {
            if (!control.IsVisible)
            {
                bounds = default;
                return false;
            }

            var p = control.TranslatePoint(default, to);
            bounds = p.HasValue ? new Rect(p.Value, control.Bounds.Size) : default;
            return p.HasValue;
        }
    }
}
