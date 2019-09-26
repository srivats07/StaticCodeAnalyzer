using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterLib;
using RegexParserLib;
using RegexParseForMetricLib;

namespace CountTargetErrorLib
{
    public class CountTargetError:ICount
    {
        public int Get(List<string> thresholdList)
        {
            int count = 0;
            IParse parse=new RegexParseForMetric();
            foreach (var line in thresholdList)
            {
                if (line.IndexOf("error",StringComparison.CurrentCultureIgnoreCase)>=0)
                {
                    count = parse.Parse(line);
                }
            }

            return count;
        }
    }
}
