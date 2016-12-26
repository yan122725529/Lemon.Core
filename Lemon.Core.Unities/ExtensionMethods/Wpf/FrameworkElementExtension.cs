using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lemon.Core.Unities.ExtensionMethods.Wpf;


public static partial class Extensions
{
        public static Rect GetBounds(this FrameworkElement element, Visual from)
        {
            var rect = Rect.Empty;

            try
            {
                var transform = element.TransformToVisual(from);
                rect = transform.TransformBounds(new Rect(0, 0, element.ActualWidth, element.ActualHeight));
                // ReSharper disable EmptyGeneralCatchClause
            }
            catch
                // ReSharper restore EmptyGeneralCatchClause
            {
            }

            return rect;
        }

        public static BitmapSource GetImageOfControl(this FrameworkElement @this)
        {
            var frameworkElement = @this;
            if (frameworkElement == null)
                return null;



            var bitmapSource = ControlToImageConvertHelper.GetImageOfControl(frameworkElement);
            return bitmapSource;
        }

        public static FrameworkElement GetChildByName(this FrameworkElement @this, string name)
        {
            return (FrameworkElement) (@this.FindName(name) ??
                                       @this.FindVisualChilds<FrameworkElement>().FirstOrDefault(c => c.Name == name));
        }
    }
