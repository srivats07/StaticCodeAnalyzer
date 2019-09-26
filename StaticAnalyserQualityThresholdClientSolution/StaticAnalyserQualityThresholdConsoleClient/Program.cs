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
using System;
using System.IO;
using System.IO.Compression;
using System.Threading;
using TemporaryDataRemoverLib;
using ZipOperationsLib;
using ZipGitRepoLib;

namespace StaticAnalyserQualityThresholdConsoleClient
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Helper helper=new Helper();
            var execute = helper.InitExecute(out var zip, out var sendInput, out var dataRemove, out var inputRecieve, out var dataExtract, out var compare);
            helper.PerformExecute(execute, zip, sendInput, inputRecieve, dataExtract, compare, dataRemove);
        }

        
    }

    
}
