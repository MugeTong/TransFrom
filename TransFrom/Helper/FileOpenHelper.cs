using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;
using WinRT.Interop;

namespace TransFrom.Helper;

public static class FileOpenHelper
{
    public static async Task<StorageFile> OpenFileAsync(List <string> fileTypeFilter)
    {
        // 打开文件选择器
        var filePicker = new FileOpenPicker
        {
            ViewMode = PickerViewMode.List,
            // TODO: 考虑根据上一次打开的位置设置默认位置
            SuggestedStartLocation = PickerLocationId.DocumentsLibrary
        };

        // GetLastOpenLocation(filePicker);
        fileTypeFilter.ForEach(filePicker.FileTypeFilter.Add);
        InitializeWithWindow.Initialize(filePicker, WindowNative.GetWindowHandle(App.Window));
        var file = await filePicker.PickSingleFileAsync();

        //
        // // 如果用户选择了文件，查找文件的父文件夹
        // var folder = await file.GetParentAsync();
        // // 如果文件没有父文件夹，直接返回文件，并且不设定上一次打开文件的位置
        // if (folder == null) return file;
        // // 否则，保存文件的父文件夹路径
        // ApplicationData.Current.LocalSettings.Values["lastOpenLocation"] = folder.Path;
        return file;
    }

    private static async void GetLastOpenLocation(FileOpenPicker filePicker)
    {
        var lastOpenLocation = ApplicationData.Current.LocalSettings.Values["lastOpenLocation"] as string;

        // 尝试获取上次位置的文件夹
        var folder = await StorageFolder.GetFolderFromPathAsync(lastOpenLocation);
        if (folder == null) return;
        Debug.WriteLine($"{typeof(FileOpenPicker).GetRuntimeMethods()}");
        // 使用反射设置初始文件夹
        var pickerInterop = typeof(FileOpenPicker).GetRuntimeMethods()
            .First(m => m.Name == "SetFolder" && m.GetParameters().Length == 1);
        pickerInterop.Invoke(filePicker, [folder]);
    }
}
