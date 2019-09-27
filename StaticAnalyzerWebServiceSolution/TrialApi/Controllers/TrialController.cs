using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;


namespace StaticAnalyzerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticAnalyzerController : ControllerBase
    {
        private readonly string path = "..\\GeneratedFiles\\" + "Output.csv";
        // GET: api/StaticAnalyzer
        [HttpGet]
        public string Get()
        {
            string outputPath = Directory.GetParent(path) + "\\Output.csv";
            if (!System.IO.File.Exists(outputPath))
                return "File does not Exists,Run the static Tool Analyzer!";

            return outputPath;
        }


        // POST: api/StaticAnalyzer
        [HttpPost]
        public bool TakeInputFolder([FromBody] string zipFilePath)
        {
            //string name =Path.GetFileNameWithoutExtension(zipFilePath);
            //string extractPath = "..\\Inputs\\" + name;
            //string fxcop = "";
            //if (Directory.Exists(extractPath))
            //{
            //    Directory.Delete(extractPath, true);
            //}
            //ZipFile.ExtractToDirectory(zipFilePath, extractPath);
            //ToolManager toolManager = new ToolManager();
            //List<string> input = new List<string>();
            //string stylecop = extractPath + "\\" + name + "\\*.cs";
            //fxcop = extractPath + "\\" + name + "\\bin\\Debug\\" + name + ".exe";
            //if(!(System.IO.File.Exists(fxcop)))
            //{
            //    fxcop = extractPath + "\\" + name + "\\bin\\Debug\\" + name + ".dll";
            //    if (!(System.IO.File.Exists(fxcop)))
            //    {
            //        throw new FileNotFoundException();
            //    }
            //}   
            //input.Add(stylecop);
            //input.Add(fxcop);
            //toolManager.StartSession(input);
            //toolManager.ParseXMlFiles();
            //toolManager.EndSession();
            return true;

        }

    }
}
