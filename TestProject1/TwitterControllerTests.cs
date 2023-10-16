using TwitterWebApp.Controllers;
using Tweetinvi.Models;
using Microsoft.AspNetCore.Mvc;

namespace TestProject1
{
    public class TwitterControllerTests
    {
        private TwitterController _controller;

        public TwitterControllerTests()
        {
            // Arrange: Initialize the controller and any dependencies
            _controller = new TwitterController();
        }

        [Fact]
        public async void TwitterAuth_ReturnsRedirectResult()
        {
            // Act: Call the TwitterAuth action
            var result = await _controller.TwitterAuth() as RedirectResult;

            // Assert: Check if the action returns a RedirectResult
            Assert.NotNull(result);
            Assert.Contains("https://api.twitter.com", result.Url);
        }

        [Fact]
        public async void ValidateTwitterAuth_ReturnsViewResult()
        {
            // Act: Call the ValidateTwitterAuth action
            var result = await _controller.ValidateTwitterAuth() as ViewResult;

            // Assert: Check if the action returns a ViewResult
            Assert.NotNull(result);

            // You can further assert the content of the result if needed
            var model = result.ViewData.Model as IUser; // Assuming ViewBag.User is of type IUser
            Assert.NotNull(model);
        }
        [Fact]
        public async Task TwitterAuthentication_ReturnsViewResult()
        {
            // Arrange
            var controller = new CallBackController(); // Create an instance of your controller

            // Act
            var result = await controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result); // Ensure that the result is of type ViewResult
        }

    }
}