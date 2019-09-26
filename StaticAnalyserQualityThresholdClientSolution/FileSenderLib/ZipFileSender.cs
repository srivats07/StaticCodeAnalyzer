using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace FileSenderLib
{
    public class ZipFileSender
    {
        private string result;


        public void SendZipFilePath(string zipFilePath)
        {
            result = HttpClientSender(zipFilePath);
            MessageBox.Show(result);
        }

        private string HttpClientSender(string filepath)
        {

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var stringContent = new StringContent(filepath, System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsJsonAsync("api/StaticAnalyzer/", filepath).Result;
            string result = null;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }
    }
}
