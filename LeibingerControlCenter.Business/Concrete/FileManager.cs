using LeibingerControlCenter.Business.Abstract;
using System.Text;

namespace LeibingerControlCenter.Business.Concrete
{
    public class FileManager : IFileManager
    {
        public async Task DownloadFile(string fileName, string content)
        {
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Jobs");

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            string filePath = Path.Combine(folderPath, fileName);

            await File.WriteAllTextAsync(filePath, content, Encoding.GetEncoding("ISO-8859-9"));
        }
    }
}