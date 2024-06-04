using System;
using System.Diagnostics;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace TransFrom.FileViewer;

public sealed partial class FileTabView
{
    public FileTabView()
    {
        InitializeComponent();
        FileTabViewControl.SelectionChanged += (_, _) => TabViewContentChanged?.Invoke(this, EventArgs.Empty);
    }

    // 创建一个监听事件，当页面切换或者页面内容发生改变时都会触发
    public event EventHandler TabViewContentChanged;

    // 将 TabView 的 CanGoBack 和 GoBack 方法暴露给 MainWindow，内部是检测当前 TabViewItem 的 Frame 是否可以返回
    public bool CanGoBack => FileTabViewControl.SelectedItem is TabViewItem { Content: Frame { CanGoBack: true } };

    public void GoBack()
    {
        if (FileTabViewControl.SelectedItem is TabViewItem { Content: Frame frame })
        {
            frame.GoBack();
        }
    }

    // 添加欢迎界面
    private void TabView_Loaded(object sender, RoutedEventArgs e)
    {
        var frame = new Frame();
        var newTab = new TabViewItem
        {
            IconSource = new FontIconSource { Glyph = "\uE706" },
            Header = "欢迎界面",
            Content = frame
        };
        frame.Navigate(typeof(WelcomePage));
        frame.Navigated += (sender, e) => TabViewContentChanged?.Invoke(this, EventArgs.Empty);
        FileTabViewControl.TabItems.Add(newTab);
        FileTabViewControl.SelectedItem = newTab;
    }

    // 添加新建文档按钮
    private void TabView_OnAddTabButtonClick(TabView sender, object args)
    {
        var frame = new Frame();
        var newTab = new TabViewItem
        {
            IconSource = new FontIconSource { Glyph = "\uE706" },
            Header = "欢迎界面",
            Content = frame
        };
        frame.Navigate(typeof(WelcomePage));
        frame.Navigated += (_, _) => TabViewContentChanged?.Invoke(this, EventArgs.Empty);
        FileTabViewControl.TabItems.Add(newTab);
        FileTabViewControl.SelectedItem = newTab;
    }

    // 添加关闭按钮
    private void TabView_OnTabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        FileTabViewControl.TabItems.Remove(args.Tab);
    }
}
