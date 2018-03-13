using SocialNet.Models;
using System.Data.Entity;

namespace SocialNet.Data
{
    public class SocialNetDbContext : DbContext
    {
        public SocialNetDbContext() : base("SocialNetConnection")
        {

        }
        public IDbSet<UserProfile> UserProfiles { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<FriendShip> FriendShips { get; set; }
    }
}
