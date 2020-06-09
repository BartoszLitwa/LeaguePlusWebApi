using LeaguePlusWebApi.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeaguePlusWebApi.Interfaces
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
