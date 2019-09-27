using System;
using System.ComponentModel;
using System.Windows;
using System.Net;
using System.Net.Http;
using System.Text;

namespace GitHubUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        WebClient clientforGit = new WebClient();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clientforGit.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri githubUri = new Uri(GitHubUrl.Text);
            clientforGit.DownloadFileAsync(githubUri, @"C:\Users\320052122\Desktop\CaseStudyPhase2\MS2-Case2-Phase1\StaticAnalyzerWebServiceSolution\Inputs\GitHub.zip");

            HttpClient httpClient = new HttpClient();
            var input =
                "C:\\Users\\320052122\\Desktop\\CaseStudyPhase2\\MS2-Case2-Phase1\\StaticAnalyzerWebServiceSolution\\Inputs\\GitHub.zip";
            HttpContent content = new StringContent(input,Encoding.UTF8,"application/json");
            var task = httpClient.PostAsync("http://localhost:44305/api/StaticAnalyzer", content);
            //var task = httpClient.GetAsync("http://localhosthttps:44305/")



        }

        private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("File Downloaded");
        }

        
    }
}
