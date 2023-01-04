using System;

using System.Net.Http;

using System.Threading;

using System.Threading.Tasks;

namespace ConsoleApp59WebClient

{

    internal class Program

    {

        static async Task Main(string[] args)

        {

            // Sync:

            string url = "https://localhost:7208/api/User/AllUsers";

            System.Net.WebClient w = new System.Net.WebClient();

            Console.WriteLine("Sync: " + w.DownloadString(new Uri(url)));

            // ASync:

            CancellationTokenSource tokenSource = new CancellationTokenSource();

            tokenSource = new CancellationTokenSource();

            CancellationToken token = tokenSource.Token;

            using (HttpClient client = new HttpClient())

            {

                token.ThrowIfCancellationRequested();

                HttpResponseMessage r = await client.GetAsync(url, token);

                Console.WriteLine("ASync: " + await r.Content.ReadAsStringAsync());

            }

            Console.ReadLine();

        }

    }

}