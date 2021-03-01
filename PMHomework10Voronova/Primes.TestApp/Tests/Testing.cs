using PrimesTestApp.Models;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PrimesTestApp.Tests
{
    public class Testing
    {
        private readonly HttpClient _httpClient;

        public Testing(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task TestIsPrimesEndpoint(string query, int expectedStatusCode)
        {
            var response = await _httpClient.GetAsync(query);
            var content = await response.Content.ReadAsStringAsync();
            if (query == "/" || !query.Contains('?'))
                ConsoleWriteResponce(query, expectedStatusCode, (int)response.StatusCode, null);
            else
                ConsoleWriteResponce(query, expectedStatusCode, (int)response.StatusCode, content);
        }

        public void ConsoleWriteResponce(string request, int expectedStatusCode, int actualStatusCode, string content)
        {
            var testResult = new TestResult(request, expectedStatusCode, actualStatusCode, expectedStatusCode == actualStatusCode);
            Console.WriteLine($"\n Request              : {testResult.Request}");
            Console.WriteLine($" Expected Status Code : {testResult.ExpectedStatusCode}");
            Console.WriteLine($" Actual Status Code   : {testResult.ActualStatusCode}");
            if (content != null && testResult.ActualStatusCode == 200)
                Console.WriteLine($" Response             : {content}");
            else if (content != null)
                Console.WriteLine($" Response             : {content.Split("errors")[2].Replace("[", "").Replace("\"", "").Replace("{", "").Replace("]", "").Replace("}", "").Remove(0,1)} ");
            WriteResult(testResult.IsSucceeded);
        }

        public void WriteResult(bool isSucceeded)
        {
            Console.ForegroundColor = isSucceeded ? ConsoleColor.Green : ConsoleColor.Red;
            Console.WriteLine(isSucceeded ? " SUCCEEDED" : " FAILED");
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
