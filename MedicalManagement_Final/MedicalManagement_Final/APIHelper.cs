using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MedicalManagement_Final
{
    public static class APIHelper
    {
        public static HttpClient ApiClient { get; set; }

        /*
        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
           // ApiClient.BaseAddress = new Uri("");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        */
    }
}