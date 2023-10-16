
# TwitterWebApp
TwitterWebApp is a web-based application designed to monitor Twitter users and their tweets by utilizing the TwitterAPI. This application provides a user-friendly interface for tracking and analyzing Twitter activity.





## Controllers
CallBackController
Action Method: The CallBackController has one action method named Index. This method is invoked when a user accesses the specified URL that this controller is mapped to.

Twitter Authentication: Within the Index method, there's an instance of the TwitterClient class from the Tweetinvi library. It's used for Twitter authentication. It requires the user's Twitter API credentials, which include a consumer key, consumer secret, and access token.

Making an API Request: The controller makes an HTTP GET request to the Twitter API using the authenticated TwitterClient. It queries the "https://api.twitter.com/2/users/me" URL.

Deserialization: After receiving a response from the Twitter API, the controller reads and deserializes the JSON content into a dynamic object, deserializedResponse. This object now contains information about the authenticated Twitter user.

View Data: The controller sets view data using the ViewData dictionary to pass user information to the associated view.

View Rendering: Finally, the controller returns a view, which can be used to display the user's information on the user interface.
 
 This controller is used for Twitter user authentication and data retrieval. It obtains information about the authenticated user and makes that information available for rendering in a view.

 TwitterController
 Action Methods: The controller has two action methods, TwitterAuth and ValidateTwitterAuth, which handle different steps in the Twitter authentication process.

Twitter Authentication (TwitterAuth):

In this method, an instance of the TwitterClient class is created using the provided consumer key and secret.
It generates a unique authentication request ID.
Constructs a callback URL by appending the authentication request ID as a query parameter to the specified URL.
Initiates the Twitter authentication process by requesting an authentication URL.
Stores the authentication token information in the authentication request store.
Redirects the user to Twitter for authentication.
Twitter Authentication Validation (ValidateTwitterAuth):

In this method, another instance of the TwitterClient class is created using the same consumer key and secret.
Extracts information from the redirection URL, typically containing the authentication token and other parameters.
Requests Twitter to generate user credentials based on the provided information.
Once successful, it creates a user client using the obtained credentials.
Retrieves the authenticated user's information from Twitter.
Sets user information in the ViewBag so that it can be displayed in the associated view.