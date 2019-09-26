using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWriterLib
{
    public class FileWriter
    {
        public string fileName = "UserFile.cs";

        public string Write(string[] linesOfCode)
        {

            string zipPath = null;
            if (linesOfCode != null)
            {

                string path = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent
                    .FullName;
                string destPath = path + "\\GeneratedCsFiles\\GeneratedCsFiles";
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }

                string destFile = Path.Combine(destPath, fileName);
                File.WriteAllLines(destFile, linesOfCode);

                //Creating a zip file
                zipPath = ZipFileCreator(path);
            }

            return zipPath;

        }

        private static string ZipFileCreator(string path)
        {
            string zipPath;
            zipPath = path + "\\GeneratedCsFiles.zip";
            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            ZipFile.CreateFromDirectory(path + "\\GeneratedCsFiles", zipPath);
            return zipPath;
        }
    }
}

