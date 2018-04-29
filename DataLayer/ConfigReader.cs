using DataLayer.RavenDB;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DataLayer
{
    public static class ConfigReader
    {
        public static string GetConnectionString() {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var sqlConnection = root.GetConnectionString("DefaultConnection");

            return sqlConnection;
        }

        public static RavenSettings GetRavenConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            var ravenSettings = root.GetSection("Raven");
           
            return new RavenSettings {
                Url = ravenSettings.GetSection("Url").Value,
                Database = ravenSettings.GetSection("Database").Value };
        }
    }
}
