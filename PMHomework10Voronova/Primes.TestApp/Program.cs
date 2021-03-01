using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PrimesTestApp.Models;
using PrimesTestApp.Tests;

namespace PrimesTestApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(JsonSerializer.Deserialize<BaseAddress>(File.ReadAllText("settings.json")).Address);

            var testing = new Testing(httpClient);
            try
            {
                await testing.TestIsPrimesEndpoint("/", 200);

                await testing.TestIsPrimesEndpoint("/primes/2", 200);

                await testing.TestIsPrimesEndpoint("/primes/4", 404);

                await testing.TestIsPrimesEndpoint("/primes?from=0&to=5", 200);

                await testing.TestIsPrimesEndpoint("/primes?from=-5&to=1", 200);

                await testing.TestIsPrimesEndpoint("/primes?to=abc", 400);

                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(" Oops! Something went wrong." + ex.Message);
            }
        }
    }
}
