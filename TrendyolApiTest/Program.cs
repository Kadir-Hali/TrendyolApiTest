using System;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;
using static TrendyolApiTest.Program;

namespace TrendyolApiTest
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            Console.ReadLine();
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
        }

        static async Task RunAsync()
        {
            string username = "hdAysqagvjVihbfsvZt6";
            string password = "idUv2kljvSa9qeLSj4gK";
            string supplierID = "330419";

            using (var client = new HttpClient())
            {
                // Send HTTP requests
                client.BaseAddress = new Uri("https://api.trendyol.com/sapigw/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password)));


                await GetAllProducts(supplierID, client);
                //await GetBrands(client);
                //await GetReturnAdress(supplierID, client);
            }
        }

        private static async Task GetReturnAdress(string supplierID, HttpClient client)
        {
            HttpResponseMessage response3 = await client.GetAsync("suppliers/" + supplierID + "/addresses");
            if (response3.IsSuccessStatusCode)
            {
                Console.WriteLine(response3.ToString());
                string product = await response3.Content.ReadAsStringAsync();
                Console.WriteLine(await response3.Content.ReadAsStringAsync());
            }
        }

        private static async Task GetAllProducts(string supplierID, HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync("suppliers/" + supplierID + "/products?approved=true");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ToString());
                string product = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }

        private static async Task GetBrands(HttpClient client)
        {
            HttpResponseMessage response2 = await client.GetAsync("brands");
            if (response2.IsSuccessStatusCode)
            {
                Console.WriteLine(response2.ToString());
                string product = await response2.Content.ReadAsStringAsync();
                Console.WriteLine(await response2.Content.ReadAsStringAsync());
            }
        }
    }  
}


