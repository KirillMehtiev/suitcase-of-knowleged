using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using FacebookIntegration.Clients.Helpers;

namespace FacebookIntegration.Clients
{
    interface IFacebookClient
    {
        Task<int> GetFriendsCount(string token);
    }

    internal class FacebookClient : IFacebookClient
    {
        private UrlConstructor _apiCtor = new UrlConstructor();
        private Mapper _mapper = new Mapper();

        // Have no idea how to handle:
        // if exeption raised while deserialization -> _mapper.ToFriends(content);
        // if exeption raised while calling FB api  -> await client.GetAsync(url)
        // TODO: fix it later :)
        public async Task<int> GetFriendsCount(string token)
        {
            var friendsCount = default(int);
            var url = _apiCtor.CreateFriendsUrl();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var friends = _mapper.ToFriends(content);

                    friendsCount = friends.Summary.Count;
                }
            }

            return friendsCount;
        }
    }
}