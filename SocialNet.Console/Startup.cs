using SocialNet.Data;

namespace SocialNet.Console
{
    public class Startup
    {
        public static void Main()
        {
            var ctx = new SocialNetDbContext();

            // Database.SetInitializer(strategy: new MigrateDatabaseToLatestVersion<SocialNetDbContext, Configuration>());

            // ctx.Database.CreateIfNotExists();
        }
    }
}
