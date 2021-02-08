using DbFirst.Models;
using DbFirst.StoredProcedures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DbFirst
{
    class Program
    {

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            BuildConfig(builder);

            var context = new PlutoContext();

            Procedures procedures = new Procedures(context);

            //calling a method which executes a stored procedure
            var courses = procedures.GetAll();

            foreach (var course in courses)
            {
                Console.WriteLine(course.Description);
            }

            //works but throws exception
            procedures.DeleteCourse(1002);


            Console.ReadLine();

            ////setup for logging with serilog
            //Log.Logger = new LoggerConfiguration()
            //    .ReadFrom.Configuration(builder.Build()) //read configuration from appsettings.json
            //    .Enrich.FromLogContext()
            //    .WriteTo.Console()
            //    .CreateLogger();

            //Log.Logger.Information("Application starting");

            //var host = Host.CreateDefaultBuilder()
            //    .ConfigureServices((context, services) =>
            //    {
            //        services.Add()
            //    })
            //    .UseSerilog()
            //    .Build();

        }

         static void BuildConfig(IConfigurationBuilder builder)
         {
            builder.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true) //get different environments(develompent, testing, production) but if not specified get a appsettings.production.json 
                .AddEnvironmentVariables();

            builder.Build().GetConnectionString("Default");
         }
        
    }
}
