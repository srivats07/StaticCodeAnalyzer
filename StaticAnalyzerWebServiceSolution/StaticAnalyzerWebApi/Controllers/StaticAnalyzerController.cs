using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Net.Http;
using ToolManagerLib;
using System.Windows;

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

        
        // POST: api/StaticAnalyzer/
        [HttpPost]
        public string TakeInputFolder([FromBody] string zipFilePath)
        {
            Helper helper = new Helper();
            helper.DownloadFiles(zipFilePath);

            return "Acknowledgment from server";
        }

        
    }
}
