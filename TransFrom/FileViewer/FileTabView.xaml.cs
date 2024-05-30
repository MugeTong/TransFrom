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
        var tab = new TabViewItem
        {
            IconSource = new FontIconSource { Glyph = "\uE706" },
            Header = "欢迎界面",
            Content = new WelcomePage()
        };
        FileViewWindow.TabItems.Add(tab);
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
        FileViewWindow.TabItems.Add(tab);
    }

    // 添加关闭按钮
    private void TabView_OnTabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
    {
        FileViewWindow.TabItems.Remove(args.Tab);
    }

}
