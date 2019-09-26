using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataExtractorLib;

namespace CsvDataExtractorLib
{
    public class CsvDataExtractor:IDataExtract
    {
        private static List<string> csvThresholdList = new List<string>();
        public List<string> ExtractData(string path)
        {
            string line;

            Thread.Sleep(10000);
            Console.WriteLine("Server works on StyleCop");
            Thread.Sleep(10000);
            Console.WriteLine("Server works on FxCop");
            Thread.Sleep(10000);
            
            
            System.IO.StreamReader reader = new StreamReader(path);

            while ((line = reader.ReadLine()) != null)
            {
                if (!line.Equals(" "))
                {
                    var delimitedLine = line.Split(',');

                    csvThresholdList.Add(delimitedLine[1]);
                }
                
            }
            reader.Dispose();
            return csvThresholdList;
        }
    }
}
