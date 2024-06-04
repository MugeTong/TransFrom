using System.Text;
using Microsoft.UI.Xaml;

namespace TransFrom;

// 想要学习更多有关 WinUI 、WinUI 项目结构和我们的项目模板，参见：http://aka.ms/winui-project-info

/// <summary>
/// 提供应用程序特定的行为以补充默认的 Application 类。
/// </summary>
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
        Window.Activate();
    }
}
