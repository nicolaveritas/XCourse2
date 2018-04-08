using Plugin.Geolocator.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Xcourse.Services
{
    public static class RestService
    {
        private static string baseUrl = "http://192.168.1.4:3000";
        public static async Task<HttpResponseMessage> PostLocation(Position location)
        {
            using (var client = new HttpClient())
            {
                var url = baseUrl + "/api/location";
                var res = await client.PostAsync(url, new StringContent(location.ToString()));
                return res;
            }
        }
    }
}
