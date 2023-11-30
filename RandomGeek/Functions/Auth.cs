using RandomGeek.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGeek.Functions
{
    public class Auth
    {
        public static bool isAuth = false;
        public static bool isAdmin(User user)
        {
            if (isAuth)
            {
                if (user.Admin == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public static User user = new User();
        public static List<Movie> randomWatched = new List<Movie>();
        public static List<Game> randomWatchedGame = new List<Game>();
    }
}
