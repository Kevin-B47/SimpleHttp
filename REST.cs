using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;

namespace TestApp.Droid {
    class REST {

        private static HttpClient Client = new HttpClient(new NativeMessageHandler());

       public static async Task<string> GetSimpleData(string url) {
            var response = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, new Uri(url)));
            if (response.IsSuccessStatusCode) {
                try {
                   return await response.Content.ReadAsStringAsync();
                }catch(HttpRequestException e) {
                    return e.Message;
                }
                
            }
            return "-1";
        }

        public static async Task<string> PostSimpleData(string url, Dictionary<string, string> body) {

            var content = new FormUrlEncodedContent(body.ToList());

            var response = await Client.PostAsync(new Uri(url), content);

            if (response.IsSuccessStatusCode) {
                try {
                    return await response.Content.ReadAsStringAsync();
                }catch(HttpRequestException e) {
                    return e.Message;
                }
            }
            else {
                return "-1";
            }


        }

    }
}