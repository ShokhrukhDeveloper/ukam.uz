#pragma warning disable
using Microsoft.AspNetCore.Http;

namespace Backend.Uckam.Services;
public class FileHelper : IFileHelper
{

    public bool FileValidateImage(IFormFile file)
    {
        var defineCsvOrXlsxFile = DefineFileExtension(file);

        if ((defineCsvOrXlsxFile.ToLower() == "png" || defineCsvOrXlsxFile.ToLower() == "jpg" || defineCsvOrXlsxFile.ToLower() == "gif" || defineCsvOrXlsxFile.ToLower() == "jpeg"))
            return true;

        return false;
    }
    public async Task<string> WriteFileAsync(IFormFile file, string folder)
    {
        var fileExtension = DefineFileExtension(file);
// "
        var filename = DateTime.Now.ToString("yyyy'-'MM'-'dd'-'hh'-'mm'-'ss") + "." + fileExtension;
        var filePath = Folder(folder) + @"\" + filename;
        Console.WriteLine($"======================={filePath}");

        using var fileStream = new FileStream(filePath, FileMode.Create, System.IO.FileAccess.Write);
        await file.CopyToAsync(fileStream);

        return folder + @"\" + filename;
    }
    public bool DeleteFileByName(string fileName)
    {
        throw new NotImplementedException();
    }

    public string GetFileByName(string fileName)
    {
        throw new NotImplementedException();
    }

    public string UpdateFileBy(string fileName, IFormFile file)
    {
        throw new NotImplementedException();
    }


    // Extention
    private string DefineFileExtension(IFormFile file)
    {
        var reverseFileName = Reverse(file.FileName);
        var count = reverseFileName.Count();
        var index = reverseFileName.IndexOf(".");
        reverseFileName = reverseFileName.Substring(0, index);

        return Reverse(reverseFileName);
    }
    //Revers
    private string Reverse(string fileName)
    {

        char[] charArray = fileName.ToCharArray();
        string reversedString = String.Empty;
        int length, index;
        length = charArray.Length - 1;
        index = length;

        while (index > -1)
        {
            reversedString = reversedString + charArray[index];
            index--;
        }

        return reversedString;
    }

    private static string Folder(string fileFolder) => Path.Combine(Directory.GetCurrentDirectory(), @"Data\Folders\" + fileFolder);
}
