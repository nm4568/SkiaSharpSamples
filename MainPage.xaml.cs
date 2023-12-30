using SkiaSharp;
using SkiaSharp.Views.Maui;
using SKCanvasView = SkiaSharp.Views.Maui.Controls.SKCanvasView;

namespace SkiaSharpSample
{
    public partial class MainPage : ContentPage
    {
        SKBitmap skBitmap;

        public MainPage()
        {
            InitializeComponent();

            skCanvasView.EnableTouchEvents = true;
            skCanvasView.PaintSurface += View_PaintSurface;
            skCanvasView.Touch += SkCanvasView_Touch;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Load and render a PNG image using SkiaSharp
            RenderSkiaSharpImage();
        }

        private void RenderSkiaSharpImage()
        {
            // Get the stream of the embedded resource
            var stream = typeof(MainPage).Assembly.GetManifestResourceStream("SkiaSharpSample.Resources.Images.dotnet_bot.png");

            // Create a SKBitmap from the stream
            skBitmap = SKBitmap.Decode(stream);

        }

        private void SkCanvasView_Touch(object? sender, SkiaSharp.Views.Maui.SKTouchEventArgs e)
        {
            switch (e.ActionType)
            {
                case SKTouchAction.Entered:
                    DebugLabel.Text = "Entered";
                    break;
                case SKTouchAction.Pressed:
                    // Handle touch-down event
                    DebugLabel.Text = "Pressed";
                    break;
                case SKTouchAction.Moved:
                    // Handle touch-move event
                    DebugLabel.Text = "TouchMove";
                    break;
                case SKTouchAction.Released:
                    // Handle touch-up event
                    DebugLabel.Text = "Released";
                    break;
                case SKTouchAction.Cancelled:
                    // Handle touch-up event
                    DebugLabel.Text = "Canceled";
                    break;
                case SKTouchAction.Exited:
                    // Handle touch-up event
                    DebugLabel.Text = "Exited";
                    break;
            }

            // Invalidate the canvas to trigger a redraw
            ((SKCanvasView)sender).InvalidateSurface();
        }

        private void View_PaintSurface(object? sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
        {
            // Get the SKCanvas from the event arguments
            var canvas = e.Surface.Canvas;

            // Clear the canvas
            canvas.Clear(SKColors.White);

            // Draw the SKBitmap onto the canvas
            canvas.DrawBitmap(skBitmap, new SKPoint(0, 0));
        }
    }
}
