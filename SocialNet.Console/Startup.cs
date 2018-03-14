using SocialNet.Data;

namespace SocialNet.Console
{
    public class Startup
    {
        public static void Main()
        {
            var ctx = new SocialNetDbContext();

            // ctx.Database.CreateIfNotExists();
        }
    }
}
