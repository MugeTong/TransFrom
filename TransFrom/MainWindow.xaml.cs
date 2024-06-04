using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace TransFrom;

/// <summary>
/// 可以自身使用或者在 Frame 内导航的空白页。
/// </summary>
public sealed partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        Closed += MainWindow_Closed;

        // 将 TabView 的 CanGoBack 和 GoBack 方法暴露给 MainWindow 用以检测和控制返回按钮的可用性
        MainNavigationView.BackRequested += (_, _) => FileTabView.GoBack();
        FileTabView.TabViewContentChanged += (_, _) => MainNavigationView.IsBackEnabled = FileTabView.CanGoBack;

        // 监听导航栏的 ItemInvoked 事件，根据点击的导航项进行页面跳转
        MainNavigationView.ItemInvoked += MainNavigationView_ItemInvoked;
    }

    // 控制窗口关闭时的行为
    private static void MainWindow_Closed(object sender, WindowEventArgs e)
    {
        Application.Current.Exit();
    }

    private void MainNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItemContainer.Tag is not string itemName) return;

        throw new NotImplementedException($"The {itemName} page is not implemented.");
    }
}
