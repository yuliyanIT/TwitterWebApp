using static System.Net.Mime.MediaTypeNames;


namespace UnitTesting
{
    public class UnitTest1
    {
        [Fact]
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
            Assert.NotNull(tweets);
            Assert.True(tweets.Count > 0);

            Assert.Contains("URL", analysisResult);

            // Optional: Add more assertions based on your specific service behavior

            // Clean up (optional): If you need to remove any test data created during the test
        }
    }
}