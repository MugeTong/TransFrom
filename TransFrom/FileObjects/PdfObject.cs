namespace TransFrom.FileObjects;

public struct PdfObject
{
    public string FileName { get; set; }
    public string Author { get; set; }
    public uint PageCount { get; set; }
    public bool IsPasswordProtected { get; set; }

}
