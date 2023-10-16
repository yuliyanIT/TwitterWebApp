using System.ComponentModel.DataAnnotations;

namespace TwitterWebApp.Models
{
    public class TwitterAccountModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; }
    }
}
