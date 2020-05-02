using AutoMapper;
using Core.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Core.Shared.Data;
using System.Globalization;
using Core.Shared.Kernel.Events;
using System;

namespace Itau.Case.Brasileirao.Web
{
  public class Startup
  {
    public IWebHostEnvironment _environment { get; }
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
      Configuration = configuration;
      _environment = env;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {

      if(_environment.IsDevelopment())
        Constants.IS_DEBUG = true;

      services.AddCors(options =>
      {
        options.AddPolicy("DefinedOrigins", builder =>
                                        {
                                          builder.AllowAnyHeader()
                                                       .AllowAnyMethod()
                                                       .WithOrigins("http://localhost")
                                                       .WithOrigins("https://localhost")
                                                       .AllowCredentials();
       }); });

      services.AddControllers().AddNewtonsoftJson(opt => {

      opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
      opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
      }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

      //DI Configuration  
      services.AddSingleton(Configuration);
      services.AddAutoMapper(typeof(Startup));
      services.InjectAll();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider sp)
    {

      var cultureInfo = new CultureInfo("pt-BR");
      cultureInfo.NumberFormat.CurrencySymbol = "R$";

      CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
      CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

      if (env.IsDevelopment())
      {
        app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

        app.UseDeveloperExceptionPage();

      } else
      {
        app.UseCors("DefinedOrigins");
      }

      app.UseHttpsRedirection();
      app.UseRouting();
      app.UseEndpoints(end =>
      {
        end.MapControllers();
        end.MapControllerRoute("default", "v1/{controller}/{action}/{id?}");
      });

    }
  }
}
