using Windows.Storage;
using Microsoft.UI.Xaml.Navigation;
using TransFrom.Helper;

namespace TransFrom.FileViewer;

public sealed partial class PdfViewerPage
{
    public PdfViewerPage()
    {
        InitializeComponent();
    }

    public string FilePath { get; private set; }
    public string FileName { get; private set; }

    // 当导航到此页时，将 StorageFile 传递给 PdfHelper.OpenPdfAsync 方法
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        // 打开 PDF 文件，并将 PdfObject 返回
        var file = e.Parameter as StorageFile;
        var PdfObject = PdfHelper.OpenPdfAsync(file);

        //

    }
}
