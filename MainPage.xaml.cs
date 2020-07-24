using System;
using Windows.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;

namespace MockMediaApp
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            DataContext = new MainPageViewModel();
        }

        private void ItemListView_PointerWheelChanged(object sender, PointerRoutedEventArgs e)
        {
            var listView = sender as ListView;
            var point = e.GetCurrentPoint(listView);

            if (point.Properties.IsHorizontalMouseWheel)
            {
                // Required to prevent the CollectionsListView from scrolling.
                e.Handled = true;

                var scrolledDistance = point.Properties.MouseWheelDelta;
                ScrollViewer scrollViewer = GetChildOfType<ScrollViewer>(listView);
                scrollViewer.ChangeView(scrollViewer.HorizontalOffset - scrolledDistance, null, null);
            }
        }

        // Helper method:
        // https://stackoverflow.com/questions/10279092/how-to-get-children-of-a-wpf-container-by-type
        public static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj == null) return null;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                var child = VisualTreeHelper.GetChild(depObj, i);

                var result = (child as T) ?? GetChildOfType<T>(child);
                if (result != null) return result;
            }
            return null;
        }
    }
}
