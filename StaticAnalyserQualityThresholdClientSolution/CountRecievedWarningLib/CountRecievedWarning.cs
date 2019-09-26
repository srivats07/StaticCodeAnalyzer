using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterLib;

namespace CountRecievedWarningLib
{
    public class CountRecievedWarning:ICount
    {
        public int Get(List<string> thresholdList)
        {
            int count = 0;
            foreach (var line in thresholdList)
            {
                if (line.IndexOf("warning", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    count++;
            }

            return count;
        }
    }
}
