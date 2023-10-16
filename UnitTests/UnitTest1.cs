using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace UnitTests
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

            // Create a sample tweet with a URL
            var testTweet = new Tweet
            {
                Text = "Sample tweet with a URL",
                CreatedAt = DateTime.Now
            };

            // Act: Retrieve and analyze the tweets
            var tweets = twitterService.RetrieveTweetsForTesting(username);
            var analysisResult = twitterService.AnalyzeTweetForTesting(testTweet);

            // Assert: Verify the results
            Assert.IsNotNull(tweets);
            Assert.IsTrue(tweets.Count > 0);

            Assert.IsTrue(analysisResult.Contains("URL"));

            // Optional: Add more assertions based on your specific service behavior

            // Clean up (optional): If you need to remove any test data created during the test
        }
    }
}
