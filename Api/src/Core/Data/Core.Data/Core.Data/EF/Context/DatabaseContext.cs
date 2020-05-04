using System;
using Core.Data.EF.Mappings;
using Core.Domain.Entities.Concrete.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace Core.Data.EF.Context
{
    public partial class DatabaseContext : DbContext
    {

        IConfiguration _configuration;
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Time> Times { get; set; }
        public DbSet<Posicao> Posicoes { get; set; }
        public DbSet<Campeonato> Campeonatos { get; set; }
        public string ConnectionString { get; set; }

        public DatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetValue<string>("ConnectionStrings:Main");
        }

        public DatabaseContext(IConfiguration configuration, DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            _configuration = configuration;
            ConnectionString = _configuration.GetValue<string>("ConnectionStrings:Main");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(ConnectionString, 
                     optionsBuilder => optionsBuilder.ServerVersion(
                                                            new Version(10, 4, 7),
                                                            ServerType.MariaDb));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new PosicaoMapping());
            modelBuilder.ApplyConfiguration(new CampeonatoMapping());
            modelBuilder.ApplyConfiguration(new TimeMapping());
            modelBuilder.ApplyConfiguration(new EstadoMapping());
        }
    }
}
