using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace _123Customers
{
    public class GlobalVariables
    {
        public static HttpClient Client = new HttpClient();

        GlobalVariables()
        {
            Client.BaseAddress = new Uri("http://localhost:56613/api");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}