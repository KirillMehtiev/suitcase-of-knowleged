using FacebookIntegration.Clients.Models;
using Newtonsoft.Json;

namespace FacebookIntegration.Clients.Helpers
{
    class Mapper
    {
        public Friends ToFriends(string friends)
        {
            var result = JsonConvert.DeserializeObject<Friends>(friends);

            // TODO: add exeption handling

            return result;
        }
    }
}