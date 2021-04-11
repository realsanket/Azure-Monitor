using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace TestingWeb_Insights
{
    class Program
    {
        static void Main(string[] args)
        {
            SendRequest().Wait();
            Console.ReadLine();
        }

        static async Task SendRequest()
        {
                string url1 = "https://appinsights5000.azurewebsites.net/Products";
                string url2 = "https://appinsights5000.azurewebsites.net/Products/Details/";

            var client = new HttpClient();

            while (true)
            {
                List<Task<string>> response = new List<Task<string>>();
                response.Add(client.GetStringAsync(url1));
                Console.WriteLine(response[0].Result.ToString());
                Thread.Sleep(2000);

                for (int i = 1; i < 4; i++)
                {
                    response.Add(client.GetStringAsync(url2 + i));
                    Console.WriteLine(response[i].Result.ToString());
                    Thread.Sleep(1000);

                }


            }

        }
    }
}
