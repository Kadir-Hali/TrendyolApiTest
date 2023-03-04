using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TrendyolApiTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            RunAsync().Wait();
            //Console.ReadLine();
            
        }
        static async Task<List<Brand>> RunAsync()
        {
            string username = AccountInfo.username;
            string password = AccountInfo.password;
            string supplierID = AccountInfo.supplierID;

                HttpClient client = new HttpClient();
                // Send HTTP requests
                client.BaseAddress = new Uri(URLs.BaseURL);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(DataFormatType.Json));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(AuthenticationType.Basic, Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(username + ":" + password)));

                //await GetAllProducts(supplierID, client);
                //await GetBrands(client);
                //await GetReturnAdress(supplierID, client);

                List<Brand> brands = new List<Brand>();

                HttpResponseMessage response = await client.GetAsync(URLs.Brands);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var brandList=JsonConvert.DeserializeObject<BrandList>(jsonString);

                    if (brandList !=null)
                    {
                        brands.AddRange(brandList.Brands);
                    }
                    
                }
            return brands;

        }
        private static async Task GetReturnAdress(string supplierID, HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(URLs.Suppliers + supplierID + URLs.Addresses);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ToString());
                string product = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        private static async Task GetAllProducts(string supplierID, HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(URLs.Suppliers + supplierID + URLs.AllProducts);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ToString());
                string product = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                
            }
        }
        private static async Task GetBrands(HttpClient client)
        {
            HttpResponseMessage response = await client.GetAsync(URLs.Brands);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ToString());
                string product = await response.Content.ReadAsStringAsync();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
    }  
}


