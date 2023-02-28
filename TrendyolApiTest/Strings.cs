using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyolApiTest
{
    public static class AccountInfo
    {
        public static string username = "hdAysqagvjVihbfsvZt6";
        public static string password = "idUv2kljvSa9qeLSj4gK";
        public static string supplierID = "330419";
    }
    public static class DataFormatType
    {
        public static string Json = "application/json";
    }
    public static class AuthenticationType
    {
        public static string Basic = "Basic";
    }

    public static class URLs
    {
        public static string BaseURL = "https://api.trendyol.com/sapigw/";
        public static string Suppliers = "suppliers/";
        public static string Addresses = "/addresses";
        public static string AllProducts = "/products?approved=true";
        public static string Brands = "brands";
    }

}
