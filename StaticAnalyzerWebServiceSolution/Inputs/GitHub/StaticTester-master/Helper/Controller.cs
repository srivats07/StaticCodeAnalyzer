using IToolDataParserLib;
using IToolDataWriterLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using FxCopToolLib;
using ToolConfigurationLib;
using ToolDataCsvWriterLib;
using ToolDataLib;
using ToolOutputDataFormatLib;
using ToolParserConfigurationLib;
using ToolParserInfoFormatLib;
using ToolRunnerLib;
/// <summary>
/// ToolManager library is for running the tools on given inputs then generating xmls files.
/// Then Parse the xml files
/// Then write the parse data into readable formate.
/// </summary>
namespace ToolManagerLib
{
    /// <summary>
    /// ToolManager class is used for generate xml using tools, parse xml then write into readable formate
    /// </summary>
    public class ToolManager
    {



        #region Properties

        public IToolDataWriter ToolDataCsvWriter { get; set; }
        public List<ToolOutputDataFormat> ToolsOutputData { get; set; } = new List<ToolOutputDataFormat>();
        #endregion

        #region StartSession Method
        /// <summary>
        /// Call every tool with corresponding inputs and generate the xml files
        /// </summary>
        /// <param name="input">list of input data</param>
        public void StartSession(List<string> input)
        {
            
            if (input.Count > 0)
            {
                string filePath = "..\\ToolsInfo.xml";
                ToolConfiguration toolConfiguration = new ToolConfiguration();
                List<ToolData> toolInfo = toolConfiguration.ReadToolInfo(filePath);
                ToolsRunner toolRunner = new ToolsRunner();
                toolRunner.RunTools(toolInfo, input);
            }
            else
            {
                string message = "Argument is not valid";
                throw new ArgumentNullException(message);
            }
        }
        #endregion

        #region ParseXMLFiles Method
        /// <summary>
        /// It is for parsing the xml files
        /// </summary>
        public void ParseXMlFiles(List<string> input)
        {
            try
            {

                string filePath = "..\\ToolsXmlParserInfo.xml";
                ToolParserConfiguration toolParserConfiguration = new ToolParserConfiguration();
                List<ToolParserInfoFormat> toolParserInfo = toolParserConfiguration.ReadToolParserInfo(filePath);
                int j = 1;
                foreach (var i in toolParserInfo)
                {
                    string startupPath = System.IO.Directory.GetCurrentDirectory();
                    Console.WriteLine("startupPath= " + startupPath);
                    Console.WriteLine(i.DllPath + "  " + i.Name);
#pragma warning disable S3885 // "Assembly.Load" should be used
                    Assembly assembly = Assembly.LoadFrom(i.DllPath);
#pragma warning restore S3885 // "Assembly.Load" should be used
                    var v = assembly.CreateInstance(i.Name) as IToolDataParser;
                    foreach (var file in input)
                    {
                        if (i.Name.Contains("StyleCop") && file.Contains("cs"))
                        {
                            string path = "..\\GeneratedFiles\\" + j + ".xml";
                            Console.WriteLine(path);
                            ToolsOutputData.AddRange(v.Parse(path));
                            
                        }
                        if (i.Name.Contains("FxCop") && file.Contains("exe"))
                        {
                            string path = "..\\GeneratedFiles\\" + j + ".xml";
                            Console.WriteLine(path);
                            ToolsOutputData.AddRange(v.Parse(path));
                            
                        }

                        j++;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new FileNotFoundException();
            }
        }
        #endregion

        #region EndSession Method
        /// <summary>
        /// Write the parse data into readable format
        /// </summary>
        public void EndSession()
        {
            try
            {
                string path = "..\\GeneratedFiles\\Output.csv";
                IToolDataWriter toolDataWriter = new ToolDataCsvWriter();
                toolDataWriter.Write(ToolsOutputData, path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new FileNotFoundException();
            }
        }
        #endregion
    }
}
