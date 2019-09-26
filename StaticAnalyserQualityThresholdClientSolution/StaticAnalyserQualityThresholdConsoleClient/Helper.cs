using System;
using System.IO;
using System.Threading;
using CompareLib;
using CsvDataExtractorLib;
using DataExtractorLib;
using DataRemoveLib;
using GitCloneExecutorLib;
using GitCommandExecuteLib;
using InputRecieverLib;
using QualityThresholdEvaluatorLib;
using QualityThresholdListRecieverLib;
using SendInputLib;
using SendProjectInputLib;
using TemporaryDataRemoverLib;
using ZipGitRepoLib;
using ZipOperationsLib;

namespace StaticAnalyserQualityThresholdConsoleClient
{
    public class Helper
    {
        private static string _outputPath =
            Path.Combine(
                @"C:\Users\320067390\Videos\StaticAnalyzerWebServiceSolution\GeneratedFiles\Output.csv");
        public IGitCommandExecute InitExecute(out IZip zip, out ISendInput sendInput, out IDataRemove dataRemove,
            out IThresholdRecieve inputRecieve, out IDataExtract dataExtract, out ICompare compare)
        {
            IGitCommandExecute execute = new GitCloneExecute();
            zip = new ZipGitRepo();
            sendInput = new SendProjectPathAsInput();
            dataRemove = new TemporaryDataRemover();

            inputRecieve = new QualityThresholdListRecieve();
            dataExtract = new CsvDataExtractor();
            compare = new QualityThresholdEvaluator();
            return execute;
        }

        public void PerformExecute(IGitCommandExecute execute, IZip zip, ISendInput sendInput,
            IThresholdRecieve inputRecieve, IDataExtract dataExtract, ICompare compare, IDataRemove dataRemove)
        {
            Console.WriteLine("Enter repo to clone:");
            var urlIn = Console.ReadLine();
            var url = ExecuteUrl(execute,urlIn);

            Thread.Sleep(10000);
            Console.WriteLine("Zip operation undergoes");
            Thread.Sleep(10000);
            Console.WriteLine("Sending zip to server");
            Thread.Sleep(10000);

            var fileName = url.Split('/')[1].Split('.')[0];

            var zipPath = PerformZipOperation(zip, sendInput, url, fileName);

            PerformSendOperation(sendInput,zipPath);

            PerformComparisonAndCleanUp(inputRecieve, dataExtract, compare, dataRemove, fileName, zipPath,_outputPath);
        }

        public string PerformZipOperation(IZip zip, ISendInput sendInput, string url, string fileName)
        {
            return zip.Zip(fileName);
        }

        public void PerformSendOperation(ISendInput sendInput, string zipPath)
        {
            sendInput.Send(zipPath);
        }

        public void PerformComparisonAndCleanUp(IThresholdRecieve inputRecieve, IDataExtract dataExtract, ICompare compare,
            IDataRemove dataRemove, string fileName, string zipPath,string outputPath)
        {
            var qualityThresholdList = inputRecieve.getThresholdList(fileName);
            var csvThresholdList = dataExtract.ExtractData(outputPath);
            compare.Compare(qualityThresholdList, csvThresholdList);
            Thread.Sleep(10000);
            dataRemove.Remove(Path.GetFullPath(Directory.GetCurrentDirectory()), zipPath, fileName);
        }


        public string ExecuteUrl(IGitCommandExecute execute,string url)
        {   
            execute.Execute(url);
            return url;
        }

        
    }
}