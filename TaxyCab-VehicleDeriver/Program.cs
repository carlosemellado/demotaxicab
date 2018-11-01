using Microsoft.Owin.Hosting;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace TaxyCab_VehicleDeriver
{
    public class Program
    {

        static void Main(string[] args)
        {
            string uriWebHooksApis = "http://localhost:58520/";
            decimal latitud = 87.1000982m;
            decimal longitud = 88.1000982m;
            while (true)
            {
                using (var httpClient = new HttpClient())
                {

                    HttpResponseMessage result = httpClient.PostAsJsonAsync($"{uriWebHooksApis}/api/journey/auth/signin", new { name = "carlos.mellado@outlook.com" }).Result;
                    var updateLocationModel = new { vehicle = new { vehicleId = "AAA-AAA" }, locations = new object[] { new { latitud = $"{latitud}", longitud = $"{longitud}" } } };
                    result = httpClient.PostAsJsonAsync($"{uriWebHooksApis}/api/vehicle/updatelocation", updateLocationModel).Result;
                    Console.WriteLine("StatusCode: {0}, Content: {1}", result.StatusCode, result.Content.ReadAsStringAsync().Result);
                    latitud += 0.0000100m;
                    longitud += 0.0000100m;
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
