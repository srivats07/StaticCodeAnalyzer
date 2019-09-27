using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ToolManagerLib;

namespace StaticAnalyzerWebApi
{
    public class Helper
    {
        
        public void DownloadFiles(string zipFilePath)
        {
           ToolManager toolManager = new ToolManager();
           string name = Path.GetFileNameWithoutExtension(zipFilePath);
           string extractPath = "..\\Inputs\\" + name;
            if (Directory.Exists(extractPath))
            {
                Directory.Delete(extractPath, true);
            }
            
            ZipFile.ExtractToDirectory(zipFilePath, extractPath);
            string[] fileDirectory = Directory.GetDirectories(extractPath);
            string styleCop = "";
            string fxCopInputs = "";
            string styleCopInputs = "";
            List<string> input = new List<string>();
            foreach (var dir in fileDirectory)
            {
                styleCopInputs = "";
                if (CheckForCsFile(dir))
                {
                    styleCop = Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories).First();
                }

                if (CheckForExeFile(dir))
                {
                    fxCopInputs = Directory.GetFiles(dir, "*.exe", SearchOption.AllDirectories).First();
                }
                else if (CheckForDllFile(dir))
                {
                    fxCopInputs = Directory.GetFiles(dir, "*.dll", SearchOption.AllDirectories).First();
                }
                else
                {
                    fxCopInputs = "";
                }




                if (styleCop.EndsWith(".cs") && File.Exists(styleCop))
                {
                    styleCopInputs = Directory.GetParent(styleCop).ToString() + "\\*.cs";
                }
                
                if (styleCopInputs != "")
                {
                    input.Add(styleCopInputs);
                }

                if (fxCopInputs != "")
                {
                    input.Add(fxCopInputs);
                }
                


                
            }

            toolManager.StartSession(input);
            toolManager.ParseXMlFiles(input);
            toolManager.EndSession();



            Thread.Sleep(50000);
        }

        private static bool CheckForExeFile(string dir)
        {
            try
            {
                return File.Exists(Directory.GetFiles(dir, "*.exe", SearchOption.AllDirectories).First());

            }
            catch (Exception )
            {

                return false;
            }
        }
        private static bool CheckForDllFile(string dir)
        {
            try
            {
                return File.Exists(Directory.GetFiles(dir, "*.dll", SearchOption.AllDirectories).First());

            }
            catch (Exception)
            {

                return false;
            }
        }
        private static bool CheckForCsFile(string dir)
        {
            try
            {
                return File.Exists(Directory.GetFiles(dir, "*.cs", SearchOption.AllDirectories).First());

            }
            catch (Exception)
            {

                return false;
            }
        }
    }
    
}
