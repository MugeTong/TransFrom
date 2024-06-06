using System;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;

namespace TransFrom.Helper;

public static class PdfHelper
{
    public static async Task<PdfDocument> OpenPdfAsync(StorageFile file)
    {
        return await PdfDocument.LoadFromFileAsync(file);
    }
}
