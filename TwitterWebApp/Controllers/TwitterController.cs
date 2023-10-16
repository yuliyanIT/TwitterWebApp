
using Microsoft.AspNetCore.Mvc;
using Tweetinvi.Auth;
using Tweetinvi.Parameters;
using Tweetinvi;
using System.Net;


namespace TwitterWebApp.Controllers
{
    public class TwitterController : Controller
    {
        private static readonly IAuthenticationRequestStore _myAuthRequestStore = new LocalAuthenticationRequestStore();
        

       
        public async Task<ActionResult> TwitterAuth()
        {
           
            var appClient = new TwitterClient("PgXBNBchcL4g4U1uhmKJ9mu2V", "GyAsZsK5M3bOQh2oCrQhz06aGmPUqcPcArBDS3E6NLQQC0Xhxr");
            var authenticationRequestId = Guid.NewGuid().ToString();
            var redirectPath = (Request.Scheme ?? "https") + "://" + (Request.Host.HasValue ? Request.Host.Value : "localhost") + "/Home/Index";


            // Add the user identifier as a query parameters that will be received by `ValidateTwitterAuth`
            var redirectURL = _myAuthRequestStore.AppendAuthenticationRequestIdToCallbackUrl(redirectPath, authenticationRequestId);
            // Initialize the authentication process
            var authenticationRequestToken = await appClient.Auth.RequestAuthenticationUrlAsync(redirectURL);
            // Store the token information in the store
            await _myAuthRequestStore.AddAuthenticationTokenAsync(authenticationRequestId, authenticationRequestToken);

            // Redirect the user to Twitter
            return new RedirectResult(authenticationRequestToken.AuthorizationURL);
        }

        public async Task<ActionResult> ValidateTwitterAuth()
        {
            var appClient = new TwitterClient("PgXBNBchcL4g4U1uhmKJ9mu2V", "GyAsZsK5M3bOQh2oCrQhz06aGmPUqcPcArBDS3E6NLQQC0Xhxr");

            // Extract the information from the redirection url
            var requestParameters = await RequestCredentialsParameters.FromCallbackUrlAsync(Request.QueryString.Value, _myAuthRequestStore);
            // Request Twitter to generate the credentials.
            var userCreds = await appClient.Auth.RequestCredentialsAsync(requestParameters);

            // Congratulations the user is now authenticated!
            var userClient = new TwitterClient(userCreds);
            var user = await userClient.Users.GetAuthenticatedUserAsync();


            ViewBag.User = user;

            return View();
        }
    }
}

        //public ActionResult Index(TweetModel twts)
        //{

        //    string key = "PgXBNBchcL4g4U1uhmKJ9mu2V";
        //    string secret = "GyAsZsK5M3bOQh2oCrQhz06aGmPUqcPcArBDS3E6NLQQC0Xhxr";
        //    string token = "1490756559080722432-jea9z3cQzCKAnvP0dYCXd5ingZLTBp";
        //    string tokenSecret = "r3AiPHjHWnJC0E76rmhDjp1AnXJTePJaqT9URzH6KPtRp";
        //    //string berToken = "AAAAAAAAAAAAAAAAAAAAADzEqQEAAAAAFothWl%2ByfnpsC02tpWfpsNs2Ezs%3DPgLcBLSD63pnSWcFvuYPe4QSXMrq131nCcDaOzNpJ8uffQxsHN";

        //    string message = twts.tweets;

        //    //Enter the Image Path if you want to upload image .

        //    // string  imagePath = @"C:\Users\appuser\Pictures\Dummy.jpg"; (Enter the Image path Here )
        //    string imagePath = string.Empty;
        //    var service = new TweetSharp.TwitterService(key, secret);
        //    service.AuthenticateWith(token, tokenSecret);

        //    //this Condition  will check weather you want to upload a image & text or only text 
        //    if (imagePath.Length > 0)
        //    {
        //        using (var stream = new FileStream(imagePath, FileMode.Open))
        //        {
        //            var result = service.SendTweetWithMedia(new SendTweetWithMediaOptions
        //            {
        //                Status = message,
        //                Images = new Dictionary<string, Stream> { { "john", stream } }
        //            });
        //        }
        //    }
        //    else // just message
        //    {
        //        var result = service.SendTweet(new SendTweetOptions
        //        {
        //            Status = message
        //        });
        //    }

        //    twts.tweets = "";
        //    return View();
        //}
        




//private readonly string _consumerKey = "your_consumer_key";
        //private readonly string _consumerSecret = "your_consumer_secret";

        //public async Task<IActionResult> Login()
        //{
        //    var oauth = new tw.OAuth(_consumerKey, _consumerSecret);
        //    var requestToken = await oauth.GetRequestTokenAsync("http://localhost:5000/twitteraccount/callback");

        //    var url = oauth.GetAuthorizationUrl(requestToken);
        //    return Redirect(url);
        //}

        //public async Task<IActionResult> Callback(string oauth_token, string oauth_verifier)
        //{
        //    var oauth = new TwitterAPI.OAuth(_consumerKey, _consumerSecret);
        //    var accessToken = await oauth.GetAccessTokenAsync(oauth_token, "your_oauth_token_secret", oauth_verifier);

        //    // Save the access token and access token secret for future use
        //    // ...

        //    return RedirectToAction("Index", "Home");
        //
   
        //
        //}        //public async Task<IActionResult> GetTweetById(string code)
        //{
        //    var appUser = "1490756559080722432-M5q6yPeBNGmfO8PjKkyrkfFFODFCKY:aPgtCOD2UemhwiunRHyI0uOLnRNlYBLJIVa47OfjFXNnS";
        //    string encodedAuth = Convert.ToBase64String(Encoding.UTF8.GetBytes(appUser));
        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("https://api.faceit.com");

             
        //        var data = new Dictionary<string, string>
        //        {
        //            {"code", code}
        //        };

        //        var url = "https://api.twitter.com/2/users/:id";
        //        var res = await client.PostAsync(url, new FormUrlEncodedContent(data));
        //        var content = await res.Content.ReadAsStringAsync();


        //        dynamic deserializedResponse = JsonConvert.DeserializeObject(content);


        //        var stream = deserializedResponse.Id;
        //        var handler = new JwtSecurityTokenHandler();

        //        var jsonToken = handler.ReadToken(stream.ToString());
        //        var tokenS = jsonToken as JwtSecurityToken;
        //        Console.WriteLine(tokenS);
        //        Console.WriteLine(stream);
        //        ViewData["UserName"] = tokenS.Claims.First(c => c.Type == "UserName").Value;
        //        ViewData["Id"] = tokenS.Claims.First(c => c.Type == "Id").Value;
        //        return View();
        //    }
        //}