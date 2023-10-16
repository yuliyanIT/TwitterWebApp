using System.ComponentModel.DataAnnotations;
using TwitterWebApp.Models;

namespace TwitterWebApp.Models
{
    public class TweetModel
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Url { get; set; }
        public int TwitterAccountId { get; set; }
        public TwitterAccountModel TwitterAccount { get; set; }
        public string tweets { get; set; }

    }
}
