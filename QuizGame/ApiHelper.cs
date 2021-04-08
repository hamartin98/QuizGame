using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace QuizGame
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            MediaTypeWithQualityHeaderValue mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            ApiClient.DefaultRequestHeaders.Accept.Add(mediaType);
        }
    }
}
