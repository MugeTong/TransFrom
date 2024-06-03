using Windows.UI.ViewManagement;
using Microsoft.UI.Xaml.Navigation;

namespace TransFrom.FileViewer;

public sealed partial class PdfViewerPage
{
    public PdfViewerPage()
    {
        InitializeComponent();
    }

    // When navigated to this page, load the EML file
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
    }
}
