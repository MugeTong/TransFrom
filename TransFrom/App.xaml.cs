using System.Text;
using Microsoft.UI.Xaml;

namespace TransFrom;

public partial class App
{
    public App()
    {
        InitializeComponent();
        // 注册编码以便将来解析不同编码的文件
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    public static Window Window { get; private set; }

    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        Window = new MainWindow();
        Window.ExtendsContentIntoTitleBar = true;
        Window.Activate();
    }
}
