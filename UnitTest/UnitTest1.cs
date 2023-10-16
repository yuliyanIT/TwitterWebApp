using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestEntireTwitterService()
        {
            // Arrange
            var twitterService = new TwitterService(/* mock dependencies */);
            var username = "test_username";

            
            var testTweet = new Tweet
            {
                Text = "Sample tweet with a URL",
                CreatedAt = DateTime.Now
            };

         
            var tweets = twitterService.RetrieveTweetsForTesting(username);
            var analysisResult = twitterService.AnalyzeTweetForTesting(testTweet);

            
            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweets.Count > 0);

            Assert.IsTrue(analysisResult.Contains("URL"));

        }
    }
}
