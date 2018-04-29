using System;
using System.Linq;
using System.Timers;
using DataLayer;
using DataLayer.RavenDB;
using Newtonsoft.Json;
using ViewProcessor;

namespace EventsConsummer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ravenSettings = ConfigReader.GetRavenConfiguration();

            var viewManager = new ViewManager(new DocumentStoreHolder(ravenSettings));
            viewManager.RestoreAllViews();
            viewManager.InterogateDatabase();
            Console.ReadKey();
        }
    }
}
