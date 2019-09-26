using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterLib;
using RegexParserLib;
using RegexParseForMetricLib;
namespace CountTargetWarningLib
{
    public class CountTargetWarning:ICount
    {
        public int Get(List<string> thresholdList)
        {
            IParse parse = new RegexParseForMetric();
            int count = 0;
            foreach (var line in thresholdList)
            {
                if (line.IndexOf("warning", StringComparison.CurrentCultureIgnoreCase) >=0)
                {
                    count = parse.Parse(line);
                }
            }

            return count;
        }
    }
}
