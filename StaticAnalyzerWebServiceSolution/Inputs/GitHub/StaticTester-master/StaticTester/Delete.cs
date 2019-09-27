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
        public List<string> ExtractData()
        {
            string line;

            Thread.Sleep(30000);
            string path = Path.Combine(@"C:\Users\320067390\Music\StaticAnalyzer\MS2-Case2-Phase1-master\StaticAnalyzerWebServiceSolution\GeneratedFiles\Output.csv");
            
            System.IO.StreamReader reader = new StreamReader(path);

            while ((line = reader.ReadLine()) != null)
            {
                var delimitedLine = line.Split(',');

                csvThresholdList.Add(delimitedLine[1]);
            }
            reader.Dispose();
            return csvThresholdList;
        }
    }
}
