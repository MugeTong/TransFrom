using Windows.Foundation;
using Windows.Graphics;
using Microsoft.UI.Xaml;

namespace TransFrom.Controls;

public sealed partial class AppTitleBar
{
    public AppTitleBar()
    {
        InitializeComponent();
        AppTitleBarControl.Height = 42;
        // 加载好后将标题栏设置为系统标题栏
        Loaded += ResetAppTitleBar;
        // 监听标题栏大小改变事件以更新拖动区域
        AppTitleBarControl.SizeChanged += (_, _) => App.Window.AppWindow.TitleBar.SetDragRectangles([GetDragRect()]);
    }

    // 重置自定义标题栏，使得导航的返回按钮可点击同时其余部分可拖动
    private void ResetAppTitleBar(object sender, RoutedEventArgs e)
    {
        App.Window.ExtendsContentIntoTitleBar = true;
        App.Window.SetTitleBar(new AppTitleBar());
        // 获取自定义标题栏的矩形区域
        App.Window.AppWindow.TitleBar.SetDragRectangles([GetDragRect()]);
    }

    private RectInt32 GetDragRect()
    {
        var transform = AppTitleBarControl.TransformToVisual(null);
        var bounds = transform.TransformBounds(
            new Rect(0, 0, AppTitleBarControl.ActualWidth, AppTitleBarControl.ActualHeight)
        );
        var scaleAdjustment = AppTitleBarControl.XamlRoot.RasterizationScale;
        return new RectInt32
        {
            X = (int)((bounds.X + 48) *scaleAdjustment),
            Y = (int)(bounds.Y * scaleAdjustment),
            Width = (int)(bounds.Width * scaleAdjustment),
            Height = (int)(bounds.Height * scaleAdjustment)
        };
    }
}
