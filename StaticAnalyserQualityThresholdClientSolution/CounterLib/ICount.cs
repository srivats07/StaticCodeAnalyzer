using System.Collections.Generic;

namespace CounterLib
{
    public interface ICount
    {
        int Get(List<string> thresholdList);
    }
}