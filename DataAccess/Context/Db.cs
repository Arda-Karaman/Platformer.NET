using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
    public class Db : DbContext
    {
        public DbSet<Block> Blocks { get; set; }
        public DbSet<Character> Characters { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCharacter> UserCharacters { get; set; }
        public Db(DbContextOptions<Db> options) : base(options) { }

    }
}
