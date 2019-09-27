using IToolDataParserLib;
using System.Collections.Generic;
using System.Linq;
using ToolOutputDataFormatLib;
using System.Xml;
using System.Data;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.IO;
using System;
/// <summary>
/// This Library is for parsing Fxcop static tool analyzer generated xml files. 
/// </summary>

namespace FxCopDataParserLib
{
    /// <summary>
    /// FxCopDataParser class contains ParseMethod which parse the xml files and return a list of data.
    /// </summary>
    public class FxCopDataParser : IToolDataParser
    {
        #region GenerateMinimalXmlMethod 
        /// <summary>
        /// Generating minimal XMl from original given xml
        /// Generated xml is easy to parse.
        /// </summary>
        /// <param name="filepath"> xml file Path</param>
        /// <returns>List of parsed data</returns>

        private string GenerateMinimalXml(string filepath)
        {
            try
            {
                XDocument doc = XDocument.Load(filepath);
                IEnumerable<XElement> issues =
                from el in doc.Descendants("Message")
                select el;

                string output = filepath;
                List<XElement> noDupes = issues.ToList();
                XmlSerializer serialiser = new XmlSerializer(typeof(List<XElement>));
                TextWriter FileStream = new StreamWriter(output);
                serialiser.Serialize(FileStream, noDupes);
                FileStream.Close();
                return output;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new FileNotFoundException();
            }

        }
        #endregion

        #region ParseMethod 
        /// <summary>
        /// After getting minimal XMl from original given xml using GenerateMinimalXmlMethod
        /// parsing of minimal xml has been done.
        /// finally a list has been returned to caller.
        /// </summary>
        /// <param name="filepath"> xml file Path</param>
        /// <returns>List of parsed data</returns>

        public List<ToolOutputDataFormat> Parse(string filePath)
        {
            try
            {
                
                XmlDocument doc = new XmlDocument();
                doc.Load(GenerateMinimalXml(filePath));
                List<ToolOutputDataFormat> fxcoplist = new List<ToolOutputDataFormat>();

                foreach (XmlNode node in doc.GetElementsByTagName("Issue"))
                {
                    string typename = "", checkid = "", category = "", id = "", innertext = "";

                    if (node.ParentNode.Attributes["TypeName"] != null)
                    {
                        typename = node.ParentNode.Attributes["TypeName"].Value;
                        if (typename.Contains(","))
                            typename = typename.Replace(",", " ");
                    }
                    if (node.ParentNode.Attributes["CheckId"] != null)
                    {
                        checkid = node.ParentNode.Attributes["CheckId"].Value;
                        if (checkid.Contains(","))
                            checkid = checkid.Replace(",", " ");
                    }
                    if (node.ParentNode.Attributes["Category"] != null)
                    {
                        category = node.ParentNode.Attributes["Category"].Value;
                        if (category.Contains(","))
                            category = category.Replace(",", " ");
                    }
                    if (node.ParentNode.Attributes["Id"] != null)
                    {
                        id = node.ParentNode.Attributes["Id"].Value;
                        if (id.Contains(","))
                            id = id.Replace(",", " ");
                    }

                    string path = "", file = "", line = "", name = "", level = "";

                    if (node.Attributes["Level"] != null)
                    {
                        level = node.Attributes["Level"].Value;
                        if (level.Contains(","))
                            level = level.Replace(",", " ");

                    }
                    if (node.Attributes["Name"] != null)
                    {
                        name = node.Attributes["Name"].Value;
                        name = name + ".";
                        if (name.Contains(","))
                            name = name.Replace(",", " ");

                    }

                    if (node.Attributes["Path"] != null)
                    {
                        path = node.Attributes["Path"].Value;
                        path = path + "\\";

                    }
                    if (node.Attributes["Line"] != null)
                    {
                        line = node.Attributes["Line"].Value;

                    }
                    if (node.Attributes["File"] != null)
                    {
                        file = node.Attributes["File"].Value;
                        if (file.Contains(","))
                            file = file.Replace(",", " ");

                    }
                    if (node.InnerText != null)
                    {

                        innertext = node.InnerText;
                        if (innertext.Contains(","))
                            innertext = innertext.Replace(",", " ");
                    }

                    fxcoplist.Add(new ToolOutputDataFormat(checkid, "FxCop", typename, category, path + file, line, name + id, level, innertext));

                }
                return fxcoplist;
            }
            catch (Exception e)
            {
                throw new FileNotFoundException("Please Provide Valid File"+ e);
            }

        }
        #endregion
    }
}
