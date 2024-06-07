using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;
using TransFrom.FileObjects;

namespace TransFrom.Helper;

public static class PdfHelper
{
    public static async Task<PdfObject> OpenPdfAsync(StorageFile file)
    {
        var pdfDocument = await PdfDocument.LoadFromFileAsync(file, null);
        var pdfObject = new PdfObject
        {
            FileName = file.Name,
            PageCount = pdfDocument.PageCount,
            IsPasswordProtected = pdfDocument.IsPasswordProtected
        };
        Debug.WriteLine("PDF 文件已打开");
        Debug.WriteLine($"文件名: {pdfObject.FileName}");
        Debug.WriteLine($"页数: {pdfObject.PageCount}");
        Debug.WriteLine($"是否受密码保护: {pdfObject.IsPasswordProtected}");
        return pdfObject;
    }
}
