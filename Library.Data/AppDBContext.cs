using Library.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Data
{
    public class AppDBContext : DbContext
    {

        private IConfiguration _config;

        public AppDBContext(IConfiguration config)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_config.GetConnectionString("AppDbConnectionString"));
            }
        }

        //entities
        public DbSet<Auth> Auth { get; set; }
        public DbSet<Book> Book { get; set; }
        public DbSet<BorrowBook> BorrowBook { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Profile> Profile { get; set; }
        public DbSet<ProfileDetail> ProfileDetail { get; set; }
        public DbSet<ProfileMember> ProfileMember { get; set; }
    }
}
