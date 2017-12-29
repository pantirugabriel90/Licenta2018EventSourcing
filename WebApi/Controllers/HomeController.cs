using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Domain;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public async System.Threading.Tasks.Task Index()
        {
            SqlEventStore eventStore = new SqlEventStore("Data Source=DESKTOP-P6BH1QB\\SQLEXPRESS;Initial Catalog=Licenta2018;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            var result =await eventStore.Get(Guid.Parse("bad279dd-4933-45af-a75b-3267747e83e8"), -1);
            var x = 5;
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Schedule()
        {
            ViewData["Message"] = "Your Schedule page.";

            return View();
        }

    }
}
