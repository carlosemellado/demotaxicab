﻿using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaxiCab_NotificationService
{

    class Program
    {
        static void Main(string[] args)
        {
            var uriClient = $"http://localhost:8085/";
            var uriWebHooksApis = $"http://localhost:58520/";

            

            // Start OWIN host 
            using (WebApp.Start<Startup>(uriClient))
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Press any key to start to recieve locations.");
                Console.ReadKey();
                Console.WriteLine("Wait 10 seconds.");
                System.Threading.Thread.Sleep(10000);

                var result = httpClient.PostAsJsonAsync($"{uriWebHooksApis}/api/journey/auth/signin", new { name="carlos.mellado@outlook.com" }).Result;


                var registration = new
                {
                    WebHookUri = $"{uriClient}/api/webhook",
                   // Description = "XXX-AAA",
                    Secret = "12345678901234567890123456789012",
                    Filters = new List<string> { "VEHICLELOCATION" }
                };
                // Register our webhook using the custom controller
                result = httpClient.PostAsJsonAsync($"{uriWebHooksApis}/api/webhooks/registrations", registration).Result;
                Console.WriteLine(result.IsSuccessStatusCode ? "Registration succesful" : "Registration failed");
                Console.ReadKey();
            }
        }
    }

      
}
