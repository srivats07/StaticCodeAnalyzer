using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SendInputLib;


namespace SendProjectInputLib
{
    public class SendProjectPathAsInput:ISendInput
    {
        public void Send(string path)
        {
            HttpClientSender(path).Wait();
        }

        private static async Task HttpClientSender(string path)
        {
            
            string uri = Path.Combine(@"http://localhost:5000");

            var client = new HttpClient {BaseAddress = new Uri(uri)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            
            HttpResponseMessage response = client.PostAsJsonAsync("api/StaticAnalyzer", path).Result;
            string result = null;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }

            Console.WriteLine(result);
            

        }
    }
}
