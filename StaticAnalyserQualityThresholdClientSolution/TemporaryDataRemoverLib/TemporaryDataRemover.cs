using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataRemoveLib;
using LibGit2Sharp;
namespace TemporaryDataRemoverLib
{
    public class TemporaryDataRemover:IDataRemove
    {
        public void Remove(string path,string fileName,string folderName)
        {
            string delimiter = Path.Combine(@"\");
            
            
            var repo=new LibGit2Sharp.Repository(path+delimiter+folderName);
            repo.Dispose();
            
            DeleteDirectory(path + delimiter + folderName);

        }
        public void DeleteDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                return;
            }

            var files = Directory.GetFiles(directoryPath);
            var directories = Directory.GetDirectories(directoryPath);

            foreach (var file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }

            foreach (var dir in directories)
            {
                DeleteDirectory(dir);
            }

            File.SetAttributes(directoryPath, FileAttributes.Normal);

            Directory.Delete(directoryPath, false);
        }
    }
}
