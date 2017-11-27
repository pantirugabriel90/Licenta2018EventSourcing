using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
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

        public IActionResult TaskList()
        {
            ViewData["Message"] = "Your task list page.";
            var result = new List<Task> {
               new Task {
                    title= "study entity framework",content=".net",details="understand code first and database first"

                },
              new Task {
                    title= "study IpSec",content="Information Security",details="Understand what problems IpSec resolves and how"

                },

            };

            return View(result);
        }
    }

    public class Task
    {
        public string title { get; set; }
        public string content { get; set; }
        public string details { get; set; }
    }
}
