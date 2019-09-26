using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RegexParserLib;

namespace RegexParseForMetricLib
{
    public class RegexParseForMetric:IParse
    {
        public int Parse(string line)
        {
            int count;
            count = Int32.Parse(Regex.Match(line, @"\d+").Value);
            return count;
        }
    }
}
