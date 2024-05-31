using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace TransFrom.FileViewer;

public sealed partial class FileTabView
{
    public FileTabView()
    {
        InitializeComponent();
    }

    // 添加欢迎界面
    private void TabView_Loaded(object sender, RoutedEventArgs e)
    {
        var newTab = new TabViewItem
        {
            IconSource = new FontIconSource { Glyph = "\uE706" },
            Header = "欢迎界面",
            Content = new Frame()
        };
        ((Frame)newTab.Content).Navigate(typeof(WelcomePage));
        FileTabViewControl.TabItems.Add(newTab);
    }

    // 添加新建文档按钮
    private void TabView_OnAddTabButtonClick(TabView sender, object args)
    {
        var newTab = new TabViewItem
        {
            IconSource = new FontIconSource { Glyph = "\uE706" },
            Header = "欢迎界面",
            Content = new Frame()
        };
        ((Frame)newTab.Content).Navigate(typeof(WelcomePage));
        FileTabViewControl.TabItems.Add(newTab);
        FileTabViewControl.SelectedItem = newTab;
    }

    // 添加关闭按钮
    private void TabView_OnTabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        FileTabViewControl.TabItems.Remove(args.Tab);
    }
}
