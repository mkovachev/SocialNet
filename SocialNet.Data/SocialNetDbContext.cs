using SocialNet.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SocialNet.Data
{
    public class SocialNetDbContext : DbContext
    {
        public SocialNetDbContext()
            : base("SocialNetConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<UserProfile> UserProfiles { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Message> Messages { get; set; }

        public IDbSet<FriendShip> FriendShips { get; set; }

    }
}
