using IToolDataParserLib;
using ToolOutputDataFormatLib;
using System;
using System.Xml;
using System.Collections.Generic;
using System.IO;
/// <summary>
/// This Library is for parsing stylecop static tool analyzer generated xml files. 
/// </summary>

namespace StyleCopDataParserLib
{

    /// <summary>
    /// StyleCopDataParser class contains ParseMethod which parse the xml files and return a list of data.
    /// </summary>
    public class StyleCopDataParser : IToolDataParser
    {
        #region ParseMethod
        /// <summary>
        /// parsing of xml has been done.
        /// finally a list has been returned to caller.
        /// </summary>
        /// <param name="filepath"> xml file Path</param>
        /// <returns>List of parsed data</returns>

        public List<ToolOutputDataFormat> Parse(string filePath)
        {
            try
            {
                Console.WriteLine("Parser"+filePath);
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);
                XmlNodeList elemlist = doc.GetElementsByTagName("Violation");
                List<ToolOutputDataFormat> stylecoplist = new List<ToolOutputDataFormat>();
                string ruleid = "", rule = "", rulenamespace = "", source = "", linenumber = "", section = "", innertext = "";

                for (int i = 0; i < elemlist.Count; i++)
                {
                    if (elemlist[i].Attributes["RuleId"] != null)
                    {
                        ruleid = elemlist[i].Attributes["RuleId"].Value;
                    }
                    if (elemlist[i].Attributes["Rule"] != null)
                    {
                        rule = elemlist[i].Attributes["Rule"].Value;
                    }
                    if (elemlist[i].Attributes["RuleNamespace"].Value != null)
                    {
                        rulenamespace = elemlist[i].Attributes["RuleNamespace"].Value;
                    }

                    if (elemlist[i].Attributes["Source"] != null)
                    {
                        source = elemlist[i].Attributes["Source"].Value;
                    }
                    if (elemlist[i].Attributes["LineNumber"] != null)
                    {
                        linenumber = elemlist[i].Attributes["LineNumber"].Value;
                    }
                    if (elemlist[i].Attributes["Section"] != null)
                    {
                        section = elemlist[i].Attributes["Section"].Value;
                    }
                    if (elemlist[i].InnerText != null)
                    {

                        innertext = elemlist[i].InnerText;
                        if (innertext.Contains(","))
                            innertext = innertext.Replace(",", " ");
                    }
                    stylecoplist.Add(new ToolOutputDataFormat(ruleid, "StyleCop", rule, rulenamespace, source, linenumber, section, "Warning", innertext));
                }
                return stylecoplist;
            }
            catch (Exception)
            {
                throw new FileNotFoundException();
            }


        }
        #endregion

    }
}

