using System;
using System.Collections.Generic;
using System.Xml;
using ToolParserInfoFormatLib;

/// <summary>
/// This Library used for parsing xml which contains all available parsers
/// </summary>

namespace ToolParserConfigurationLib
{
    /// <summary>
    /// ToolParserConfiguration contains ReadToolParserInfo Method which parse xml which contains parsers information
    /// That will be used for calling parsers whenever that is needed.
    /// </summary>
    public class ToolParserConfiguration
    {
        #region ReadToolParserInfo Method
        /// <summary>
        /// ReadToolParserInfo is method which is used for parsing parsers information.
        /// </summary>
        /// <param name="filePath">This represents the path of the file</param>
        /// <returns>list of data</returns>
        public List<ToolParserInfoFormat> ReadToolParserInfo(string filePath)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(filePath);
            XmlNodeList elemlist = doc.GetElementsByTagName("Parser");
            Console.WriteLine(elemlist.Count);
            List<ToolParserInfoFormat> toolParserList = new List<ToolParserInfoFormat>();
            string name = "", dllPath = "";

            for (int i = 0; i < elemlist.Count; i++)
            {
                if (elemlist[i].Attributes["Name"] != null)
                {
                    name = elemlist[i].Attributes["Name"].Value;
                }
                if (elemlist[i].Attributes["DllPath"] != null)
                {
                    dllPath = elemlist[i].Attributes["DllPath"].Value;
                }
                toolParserList.Add(new ToolParserInfoFormat(name, dllPath));
            }
            return toolParserList;
        }
        #endregion

    }
}
