using System;
using System.IO;
namespace GRChelper.Core.Services;

public class StorageService
{
    private string _basePath;

    public StorageService()
    {
        _basePath = GetAppDataPath();
        Directory.CreateDirectory(_basePath);
    }

    private static string GetAppDataPath()
    {
        var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        return Path.Combine(appData, "GRChelper");
    }

    public string GetFilePath(string MyFile)
    {
        return Path.Combine(_basePath, MyFile);
    }

    public void SaveText(string MyFileName, string MyContent)
    {
        var path = GetFilePath(MyFileName);
        File.WriteAllText(path, MyContent);
    }

    
}