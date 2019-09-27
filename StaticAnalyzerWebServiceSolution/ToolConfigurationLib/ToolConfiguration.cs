using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using ToolDataLib;

/// <summary>
/// This Library is for parsing Tool information and storing in a decided formate.
/// </summary>

namespace ToolConfigurationLib
{
    /// <summary>
    /// ToolConfiguration is having ReadToolInfo method that read data of the tools from xml files.
    /// </summary>
    public class ToolConfiguration
    {
        #region ReadToolInfoMethod
        /// <summary>
        /// ReadToolInfo Method is reading the tools information.
        /// </summary>
        /// <param name="fileName"> file path of ToolInfo xml file</param>
        /// <returns>list of data in ToolData Format</returns>
        public List<ToolData> ReadToolInfo(string fileName)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(fileName);
                XmlNodeList elemlist = doc.GetElementsByTagName("Tool");
                Console.WriteLine(elemlist.Count);
                List<ToolData> toolList = new List<ToolData>();
                string toolExe = "", outputDirectoryPath = "", toolName = "", toolDLLPath = "";

                for (int i = 0; i < elemlist.Count; i++)
                {
                    if (elemlist[i].Attributes["ToolName"] != null)
                    {
                        toolName = elemlist[i].Attributes["ToolName"].Value;
                    }
                    if (elemlist[i].Attributes["OutputDirectory"] != null)
                    {
                        outputDirectoryPath = elemlist[i].Attributes["OutputDirectory"].Value;
                    }
                    if (elemlist[i].Attributes["ExeFilePath"] != null)
                    {
                        toolExe = elemlist[i].Attributes["ExeFilePath"].Value;
                    }
                    if (elemlist[i].Attributes["ToolDllPath"] != null)
                    {
                        toolDLLPath = elemlist[i].Attributes["ToolDllPath"].Value;
                    }
                    Console.WriteLine("xml =" + toolDLLPath);
                    toolList.Add(new ToolData(toolExe, outputDirectoryPath, toolName, toolDLLPath));
                }
                return toolList;
            }
            catch(Exception e)
            {
                throw new FileNotFoundException("File is not valid"+e);
            }
        }
        #endregion

    }
}
