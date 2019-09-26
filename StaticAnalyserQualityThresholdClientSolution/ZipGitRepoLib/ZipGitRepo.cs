using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZipOperationsLib;

namespace ZipGitRepoLib
{
    public class ZipGitRepo:IZip
    {
        public string Zip(string fileName)
        {
            string delimiter = Path.Combine(@"\");
            var sourcePath = Path.GetFullPath(Directory.GetCurrentDirectory()) + delimiter + fileName;
            var zipPath = Path.GetFullPath(Directory.GetCurrentDirectory()) + delimiter + fileName + ".zip";
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }
            ZipFile.CreateFromDirectory(sourcePath, zipPath);

            
            return zipPath;
        }
    }
}
