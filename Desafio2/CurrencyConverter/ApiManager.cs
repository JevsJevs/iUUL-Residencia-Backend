using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CurrencyConverter {
    internal class ApiManager {

        public HttpClient Client { get; set; }

        public ApiManager() {
            //Cria o cliente http
            using HttpClient cli = new HttpClient();
            cli.BaseAddress = new Uri("https://api.exchangerate.host");
            cli.DefaultRequestHeaders.Accept.Clear();
            cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client = cli;
        }

        public async Task ExchangeCurrencyAPIAsync(string originCrcy, string exchangeCrcy, string value) {
            //https://learn.microsoft.com/en-us/dotnet/fundamentals/networking/http/httpclient

            using HttpClient cli = new HttpClient();
            cli.BaseAddress = new Uri("https://api.exchangerate.host");
            cli.DefaultRequestHeaders.Accept.Clear();
            cli.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var returnedJson = await cli.GetStringAsync($"convert?from={originCrcy}&to={exchangeCrcy}&value={value}");

            Console.WriteLine(returnedJson);
        }

    }
}
