using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using FileSenderLib;
using FileWriterLib;
using Path = System.Windows.Shapes.Path;

namespace ClientGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FileWriter fileWrite = new FileWriter();
        WebClient clientforGit = new WebClient();
        private string filePath =
            Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName+@"\"+ 
                "UserFile.cs";
        


        FileSenderLib.ZipFileSender zipFileSender = new ZipFileSender();


        private readonly string gitHubPath1 =
            @"C:\Users\320067390\Videos\StaticAnalyzerWebServiceSolution\GitHubZipFiles\GitHub.zip";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clientforGit.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri githubUri = new Uri(GitHubUrl.Text);
            clientforGit.DownloadFileAsync(githubUri, gitHubPath1);

        }

        private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File found successfully and passed to server analyzing");
            
            zipFileSender.SendZipFilePath(gitHubPath1);
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            string EntireCode = new TextRange(CodeSnippets.Document.ContentStart, CodeSnippets.Document.ContentEnd)
                .Text;
            MessageBox.Show(EntireCode);
            if (!string.IsNullOrWhiteSpace(EntireCode))
            {
                string[] linesOfCode = EntireCode.Split('\n');
                string zipPath = fileWrite.Write(linesOfCode);
                MessageBox.Show(zipPath);
                zipFileSender.SendZipFilePath(zipPath);
            }
            else
            {
                MessageBox.Show("Please enter Code snippets");
            }


        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            
            Process.Start(System.IO.Path.GetFullPath(Directory.GetCurrentDirectory())+ @"\StaticAnalyserQualityThresholdConsoleClient.exe");

        }
    }
}
