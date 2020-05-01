using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Core.Data.EF.Context
{
  public class DatabaseContextFactory : IDesignTimeDbContextFactory<DatabaseContext>
  {

    private IConfiguration _configuration;

    public DatabaseContextFactory()
    {

      //necessário para gerar as migrations para o contexto do EF
      var envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
      _configuration = new ConfigurationBuilder()
           .SetBasePath(Path.Combine(Directory.GetCurrentDirectory() + $@"..\..\..\..\..\Web"))
           .AddJsonFile("appsettings.json", optional: false)
           .AddJsonFile($"appsettings.{envName}.json", optional: true)
           .Build(); ;
    }

    public DatabaseContext CreateDbContext(string[] args)
    {
      var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
      return new DatabaseContext(_configuration, optionsBuilder.Options);
    }
  }
}
