using System.Collections.Generic;

namespace WebDataRecieverLib
{
    public interface IWebDataRecieve
    {
        List<string> RecieveWebData(string fileName);
    }
}