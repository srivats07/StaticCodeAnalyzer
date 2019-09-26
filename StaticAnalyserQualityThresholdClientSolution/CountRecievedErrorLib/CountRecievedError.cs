using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CounterLib;

namespace CountRecievedErrorLib
{
    public class CountRecievedError:ICount
    {
        public int Get(List<string> thresholdList)
        {
            int count = 0;
            foreach (var line in thresholdList)
            {
                if (line.IndexOf("error", StringComparison.CurrentCultureIgnoreCase) >= 0)
                    count++;
            }

            return count;
        }
    }
}
