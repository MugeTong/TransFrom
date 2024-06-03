using System;
using Microsoft.UI.Xaml;
using Windows.Storage.Pickers;
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
        MainNavigationView.BackRequested += (sender, e) => FileTabView.GoBack();
        FileTabView.TabViewContentChanged += (sender, e) => MainNavigationView.IsBackEnabled = FileTabView.CanGoBack;
    }

    // 控制窗口关闭时的行为
    private void MainWindow_Closed(object sender, WindowEventArgs e)
    {
        Application.Current.Exit();
    }

    private void MainNavigationView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
    {
        if (args.InvokedItemContainer.Tag is not string itemName) return;

        throw new NotImplementedException($"The {itemName} page is not implemented.");
    }
}
