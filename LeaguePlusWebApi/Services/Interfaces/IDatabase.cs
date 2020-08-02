using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    public interface IDatabase
    {
        Task<bool> SaveChanges();

        Task<User> GetUserData(UserCred userCred);

        Task<User> CreateAccount(UserCred userCred);

        Task UpdateFavSummoners(UserCred userCred, List<Summoner> summoners);

        Task UpdateUserSummoner();

        Task<bool> CheckIfUserExists(UserCred userCred);
    }
}
