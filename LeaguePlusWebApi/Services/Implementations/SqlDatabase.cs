using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi
{
    public class SqlDatabase : IDatabase
    {
        private readonly ApplicationDbContext db;

        public SqlDatabase(ApplicationDbContext db)
        {
            this.db = db;
        }
    }
}
