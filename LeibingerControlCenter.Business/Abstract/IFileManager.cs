using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeibingerControlCenter.Business.Abstract
{
    public interface IFileManager
    {
        Task DownloadFile(string fileName,string content);
    }
}
