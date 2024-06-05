using System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace TransFrom.FileViewer;

// 传递给子组件的接口，用于在打开文件后添加 TabViewItem
public interface IFileTabView
{
    void AddTabItem(IconSource iconSource, string header, Frame frame);
}

public sealed partial class FileTabView : IFileTabView
{
    public FileTabView()
    {
        InitializeComponent();
        WelcomBackgroundPage.ParentFileTabView = this;
        // 检查页面的数目事件，用于控制欢迎界面的显示
        FileTabViewControl.TabItemsChanged += ChangeBackgroundFrame;
        // 监听页面切换事件，用于控制返回按钮的可用性
        FileTabViewControl.SelectionChanged += (_, _) => TabViewContentChanged?.Invoke(this, EventArgs.Empty);
        // 指定关闭按钮的行为
        FileTabViewControl.TabCloseRequested += (_, args) => FileTabViewControl.TabItems.Remove(args.Tab);
    }

    // 创建一个监听事件，当页面切换或者页面内容发生改变时都会触发
    public event EventHandler TabViewContentChanged;

    // 将 TabView 的 CanGoBack 和 GoBack 方法暴露出来，内部是检测当前 TabViewItem 的 Frame 是否可以返回
    public bool CanGoBack => FileTabViewControl.SelectedItem is TabViewItem { Content: Frame { CanGoBack: true } };

    public void GoBack()
    {
        if (FileTabViewControl.SelectedItem is TabViewItem { Content: Frame frame })
        {
            frame.GoBack();
        }
    }

    // 增添一个添加页面的接口
    public void AddTabItem(IconSource iconSource, string header, Frame frame)
    {
        var newTab = new TabViewItem
        {
            IconSource = iconSource,
            Header = header,
            Content = frame
        };
        // 为 Frame 添加导航事件，当页面发生改变时触发 TabViewContentChanged 事件，以便更新返回按钮的可用性
        frame.Navigated += (_, _) => TabViewContentChanged?.Invoke(this, EventArgs.Empty);
        FileTabViewControl.TabItems.Add(newTab);
        FileTabViewControl.SelectedItem = newTab;
    }

    // 当 TabView 的 TabItems 发生改变时，检查是否还存在 TabViewItem，如果没有则添加欢迎界面
    private void ChangeBackgroundFrame(object sender, object e)
    {
        WelcomBackgroundPage.Visibility =
            FileTabViewControl.TabItems.Count == 0 ? Visibility.Visible : Visibility.Collapsed;
    }

    //
    // // 添加新建文档按钮
    // private void TabView_OnAddTabButtonClick(TabView sender, object args)
    // {
    //     var frame = new Frame();
    //     var newTab = new TabViewItem
    //     {
    //         IconSource = new FontIconSource { Glyph = "\uE706" },
    //         Header = "欢迎界面",
    //         Content = frame
    //     };
    //     frame.Navigate(typeof(WelcomePage));
    //     frame.Navigated += (_, _) => TabViewContentChanged?.Invoke(this, EventArgs.Empty);
    //     FileTabViewControl.TabItems.Add(newTab);
    //     FileTabViewControl.SelectedItem = newTab;
    // }
}
