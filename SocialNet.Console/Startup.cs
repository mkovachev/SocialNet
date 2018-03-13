using SocialNet.Data;

namespace SocialNet.Console
{
    public class Startup
    {
        public static void Main()
        {
            var dbContext = new SocialNetDbContext();
        }
    }
}
