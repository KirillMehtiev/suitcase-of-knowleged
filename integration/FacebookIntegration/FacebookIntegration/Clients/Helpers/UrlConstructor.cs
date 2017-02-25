namespace FacebookIntegration.Clients.Helpers
{
    public class UrlConstructor
    {
        // Facebook settings
        const string ApiVersion = "v2.8";
        const string FacebookGraph = "https://graph.facebook.com";
        const string FriendList = "friendlists";

        public string CreateFriendsUrl(string userId = "me")
        {
            return string.Join("/", FacebookGraph, ApiVersion, userId, FriendList);
        }
    }
}