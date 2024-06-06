using System.IO;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using TransFrom.Helper;

namespace TransFrom.FileViewer;

public sealed partial class WelcomePage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    // 将父级 IFileTabView 传递给欢迎界面，以便在打开文件后添加 TabViewItem
    public IFileTabView ParentFileTabView { get; set; }

    private async void FileOpenButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        // 打开文件选择器
        var file = await FileOpenHelper.OpenFileAsync([".pdf"]);
        if (file == null) return;

        // 判断文件类型并打开(file);
        var fileExtension = Path.GetExtension(file.Name);
        if (fileExtension == null) return;
        switch (fileExtension.ToLower())
        {
            case ".pdf":
                var frame = new Frame();
                frame.Navigate(typeof(PdfViewerPage), file);
                ParentFileTabView?.AddTabItem(new FontIconSource { Glyph = "\uE706" }, file.Name, frame);
                break;
            case ".docx":
            case ".doc":
                break;
        }
    }
}
