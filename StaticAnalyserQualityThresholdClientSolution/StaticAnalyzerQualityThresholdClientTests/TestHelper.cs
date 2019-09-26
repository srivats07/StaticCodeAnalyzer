using System.Collections.Generic;
using CompareLib;
using DataExtractorLib;
using DataRemoveLib;
using InputRecieverLib;

namespace StaticAnalyzerQualityThresholdClientTests
{
    public class TestHelper
    {
        public class FakeGetThresholdListStub : IThresholdRecieve
        {
            public List<string> getThresholdList(string fileName)
            {
                return new List<string>();
            }
        }
        public class FakeExtractDataStub : IDataExtract
        {
            public List<string> ExtractData(string path)
            {
                return new List<string>();
            }
        }
        public class FakeCompareStub : ICompare
        {
            public void Compare(List<string> qualityThresholdList, List<string> csvThresholdList)
            {
             /*
             * Stub for Testing
             */
            }
        }

        public class FakeRemoveStub : IDataRemove
        {
            public void Remove(string path, string fileName, string folderName)
            {
                /*
                 * Stub for Testing
                 */
            }
        }
    }
}