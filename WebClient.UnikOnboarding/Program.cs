<<<<<<< HEAD
﻿using System;

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

=======
﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

namespace WebClient.UnikOnBoarding
{

    public class Program
    {
        public Program() // Dependency injects each service frontend which should be similar-ish to this one
        {
            
        }

        static void Main(string[] args)
        {
            string[] services = { "Booking", "Project", "ProjectUsers", "Task", "User" };
            foreach (var service in services)
            {
                var index = Array.FindIndex(services, nr => nr.Contains(service));
                Console.WriteLine($"{index.ToString()}: {service}");
                Console.WriteLine("");
            }

            int value;
            string number;
            do
            {
                Console.Write("Choose Service (number): ");
                number = Console.ReadLine();
            } while ((!string.IsNullOrEmpty(number)) || (!int.TryParse(number, out value)));

            value = Convert.ToInt32(number);

            switch (value)
            {
                default:
                    Console.WriteLine("No number was selected.");
                    break;
                
                // Each case calls a method, which then gives the user a list of each method that every service has, to which the has to pick one.
                // Each method should return a list to show the result of the performed action.
                case 0:
                    //
                    break;

                case 1:
                    //
                    break;

                case 2:
                    //
                    break;

                case 3:
                    //
                    break;

                case 4:
                    //
                    break;
            }
        }
    }
    
>>>>>>> Task
}