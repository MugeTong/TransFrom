using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace TransFrom;

/// <summary>
/// 可以自身使用或者在 Frame 内导航的空白页。
/// </summary>
public sealed partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // 添加欢迎界面
    private void TabView_Loaded(object sender, RoutedEventArgs e)
    {
        var tab = new TabViewItem
        {
            IconSource = new FontIconSource { Glyph = "\uE706" },
            Header = "欢迎界面",
            Content = new WelcomePage()
        };
        FileTabView.TabItems.Add(tab);
    }

    // 添加新建文档按钮
    private void TabView_OnAddTabButtonClick(TabView sender, object args)
    {
        var tab = new TabViewItem
        {
            IconSource = new FontIconSource { Glyph = "\uE8B6" },
            Header = "新建文档",
            Content = new TextBlock { Text = "新建文档" }
        };
        FileTabView.TabItems.Add(tab);
    }

    // 添加关闭按钮
    private void TabView_OnTabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        FileTabView.TabItems.Remove(args.Tab);
    }
}
