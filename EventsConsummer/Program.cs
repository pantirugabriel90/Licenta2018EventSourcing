using System;
using System.Linq;
using System.Timers;
using DataLayer;
using Domain.Events.Tasks;
using Newtonsoft.Json;
using ViewProcessor;

namespace EventsConsummer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var viewHandler=new ViewsHandler();
            viewHandler.InterogateDatabase();

        }

       
    }
}
