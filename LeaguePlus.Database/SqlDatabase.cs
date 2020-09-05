using LeaguePlus.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlus.Database
{
    public class SqlDatabase : IDatabase
    {
        private readonly ApplicationDbContext _db;

        public SqlDatabase(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<bool> CheckIfUserExists(UserCred userCred)
        {
            return await _db.Users.AnyAsync(x => x.Username == userCred.Username && x.Password == userCred.Password);
        }

        public async Task<User> CreateAccount(UserCred userCred)
        {
            if (await CheckIfUserExists(userCred))
                return null;

            var user = new User
            {
                Username = userCred.Username,
                Password = userCred.Password,
                CreationTime = DateTime.Now,
            };

            await _db.Users.AddAsync(user);

            await SaveChanges();

            return user;
        }

        public async Task<User> GetUserData(UserCred userCred)
        {
            if (userCred == null || string.IsNullOrEmpty(userCred.Username) || string.IsNullOrEmpty(userCred.Password))
                return null;

            return await _db.Users.FirstOrDefaultAsync(
                x => x.Username == userCred.Username && x.Password == userCred.Password);
        }

        public async Task<bool> SaveChanges()
        {
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task UpdateFavSummoners(UserCred userCred, List<Summoner> summoners)
        {
            var user = await GetUserData(userCred);

            if (summoners.Count() == 0)
                return;

            user.summoners.AddRange(summoners);
        }

        public Task UpdateUserSummoner()
        {
            throw new NotImplementedException();
        }
    }
}
