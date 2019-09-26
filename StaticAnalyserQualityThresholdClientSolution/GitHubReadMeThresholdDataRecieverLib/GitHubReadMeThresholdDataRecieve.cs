using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebDataRecieverLib;

namespace GitHubReadMeThresholdDataRecieverLib
{
    public class GitHubReadMeThresholdDataRecieve:IWebDataRecieve
    {
        private static List<string> qualityThresholdList=new List<string>();
        public List<string> RecieveWebData(string fileName)
        {
            string line;

            string path= Path.GetFullPath(Directory.GetParent(Directory.GetCurrentDirectory()).ToString())+ @"\Debug\"+fileName+@"\ReadMe.md";
            System.IO.StreamReader reader = new StreamReader(path);
            
            while ((line=reader.ReadLine())!=null)
            {
                qualityThresholdList.Add(line);
            }
            reader.Dispose();
            return qualityThresholdList;

        }

        
    }
}
