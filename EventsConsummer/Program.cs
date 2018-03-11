using System;
using System.Linq;
using System.Timers;
using DataLayer;
using Newtonsoft.Json;
using ViewProcessor;

namespace EventsConsummer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var viewManager = new ViewManager();
            viewManager.DeleteAllViews();
            viewManager.InterogateDatabase();
            Console.ReadKey();

        }


    }
}
