using System.Collections.Generic;

namespace InputRecieverLib
{
    public interface IThresholdRecieve
    {
        List<string> getThresholdList(string fileName);
    }
}