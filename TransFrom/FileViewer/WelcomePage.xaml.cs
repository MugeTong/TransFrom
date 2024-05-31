using System;
using Windows.Storage.Pickers;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinRT.Interop;

namespace TransFrom.FileViewer;

public sealed partial class WelcomePage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void FileOpenButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        // 打开文件选择器
        var filePicker = new FileOpenPicker
        {
            ViewMode = PickerViewMode.List,
            // TODO: 考虑根据上一次打开的位置设置默认位置
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        };
        filePicker.FileTypeFilter.Add("*");
        InitializeWithWindow.Initialize(filePicker, WindowNative.GetWindowHandle(new Window()));
        var file = await filePicker.PickSingleFileAsync();
        if (file != null)
        {
            // 判断文件类型并打开(file);
            switch (file.Name)
            {
                case "test.eml":
                    Frame.Navigate(typeof(PdfViewerPage), file);
                    break;
                case "test.pdf":
                    break;
                default:
                    var dialog = new ContentDialog
                    {
                        Title = "Just Kidding",
                        Content = "In development.",
                        CloseButtonText = "OK",
                        XamlRoot = XamlRoot
                    };
                    await dialog.ShowAsync();
                    break;
            }
        }
    }
}
