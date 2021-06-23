using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Bifrost_Website.modals;

namespace Bifrost_Website
{
    public class Api_call
    {
        private static readonly HttpClient client = new HttpClient();
        private IEnumerable<string> test;

        public async Task<idModal> Login(string username, string password)
        {
            var values = new Dictionary<string, string>
            {
                { "username", username },
                { "password", password }
            };

            var content = new FormUrlEncodedContent(values);

            var response = await client.PostAsync("https://bifrostremote.com/auth/authenticate?username=" + username + "&password=" + password, content);

            var responseString = await response.Content.ReadAsStringAsync();
            var responseCookie1 = "";
            var responseCookie2 = "";
            if (response.Headers.TryGetValues("set-cookie", out test))
            {
                responseCookie1 = response.Headers.GetValues("set-cookie").FirstOrDefault().Remove(16);
                responseCookie2 = responseCookie1.Remove(responseCookie1.Length - 32, 32);
            }
            int responseCode = (int)response.StatusCode;
            idModal id = new idModal();
            if (responseCode == 200)
            {
                id.cookie = responseCookie2;
                id.uid = responseString;
            }
            return id;
        }
    }
}
