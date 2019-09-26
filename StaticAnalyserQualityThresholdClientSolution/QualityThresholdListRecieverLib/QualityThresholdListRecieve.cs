using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InputRecieverLib;
using WebDataRecieverLib;
using GitHubReadMeThresholdDataRecieverLib;
namespace QualityThresholdListRecieverLib
{
    public class QualityThresholdListRecieve:IThresholdRecieve
    {
        public List<string> getThresholdList(string fileName)
        {
            IWebDataRecieve webDataRecieve=new GitHubReadMeThresholdDataRecieve();
            return (webDataRecieve.RecieveWebData(fileName));
        }
    }
}
