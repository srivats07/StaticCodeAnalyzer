using System.Collections.Generic;

namespace CompareLib
{
    public interface ICompare
    {
        void Compare(List<string> qualityThresholdList, List<string> csvThresholdList);
    }
}