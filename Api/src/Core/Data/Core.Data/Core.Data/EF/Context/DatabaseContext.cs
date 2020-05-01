using System;
using System.Threading.Tasks;
using Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Core.Data.EF.Context
{


    public partial class DatabaseContext : DbContext
    {


        IConfiguration _configuration;

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DatabaseContext(IConfiguration configuration, DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            _configuration = configuration;
        }

     

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(_configuration.GetValue<string>("ConnectionStrings:Main"), 
                     optionsBuilder => optionsBuilder.ServerVersion(
                                                            new Version(10, 4, 7),
                                                            ServerType.MariaDb));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

     

   
        }
    }
}
