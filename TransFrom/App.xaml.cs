using System.Text;
using Microsoft.UI.Xaml;

namespace TransFrom;

// 想要学习更多有关 WinUI 、WinUI 项目结构和我们的项目模板，参见：http://aka.ms/winui-project-info

/// <summary>
/// 提供应用程序特定的行为以补充默认的 Application 类。
/// </summary>
public partial class App
{
    /// <summary>
    /// 初始化单例应用程序对象。这是执行的第一行已编写代码，逻辑等同于 main() 或 WinMain()。
    /// </summary>
    public App()
    {
        InitializeComponent();
        // 注册编码以便将来解析不同编码的文件
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
    }

    /// <summary>
    /// 在应用程序由最终用户正常启动时调用。
    /// </summary>
    /// <param name="args">有关启动请求和过程的详细信息。</param>
    protected override void OnLaunched(LaunchActivatedEventArgs args)
    {
        var mainWindow = new MainWindow();
        mainWindow.Activate();
        mainWindow.ExtendsContentIntoTitleBar = true;
    }
}
