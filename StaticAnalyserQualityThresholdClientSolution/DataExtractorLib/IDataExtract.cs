using System.Collections.Generic;
using System.IO;

namespace DataExtractorLib
{
    public interface IDataExtract
    {
        List<string> ExtractData(string path);
    }
}