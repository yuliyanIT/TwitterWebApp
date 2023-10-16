using DevDefined.OAuth.Consumer;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;
using Microsoft.Owin.Security.OAuth;
using DevDefined.OAuth.Framework;
using Newtonsoft.Json;
using Tweetinvi;

namespace TwitterWebApp.Controllers
{
    public class CallBackController : Controller
    {
        public async Task<IActionResult> Index()
        {

            dynamic deserializedResponse = "";
            using (var client = new HttpClient())
            {
                var auth = new TwitterClient("1490756559080722432-qKq3jnhXiCZJHm0uABjzYe1uKIQ7Dx", "z0poGZ3vA2Bd3uWOjMEhuKfPl4P8Yt5n6vKvpo3G4X7u2", 
                    "AAAAAAAAAAAAAAAAAAAAADzEqQEAAAAA7Wt8gUnhoqlK0pLuxgKCl0WuAt4%3DIPtMGcYCcdZlGnJapddsMrKiSWbd44N2xOCPMwq0RUqzdHD3Xm");
                //string auth = "AAAAAAAAAAAAAAAAAAAAADzEqQEAAAAA7Wt8gUnhoqlK0pLuxgKCl0WuAt4%3DIPtMGcYCcdZlGnJapddsMrKiSWbd44N2xOCPMwq0RUqzdHD3Xm";
                client.BaseAddress = new Uri("https://api.twitter.com");
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {auth}");
                //HTTP GET

                var url = "https://api.twitter.com/2/users/me";
                var res = await client.GetAsync(url);
                var content = await res.Content.ReadAsStringAsync();

                deserializedResponse = JsonConvert.DeserializeObject(content);
            }

            ViewData["id"] = deserializedResponse.id;
            ViewData["name"] = deserializedResponse.name;
            ViewData["username"] = deserializedResponse.username;

            return View();

        }
    }
}
