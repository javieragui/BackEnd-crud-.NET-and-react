using System;
using Microsoft.EntityFrameworkCore;
using UdemyManageAPI.Models;

namespace UdemyManageAPI.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> persons { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}