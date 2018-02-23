using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using Domain;
using Domain.Events;
using CQRSlite.Events;
using CQRSlite.Domain;
using Services.Commands.Task;
using Services.Commands.Topic;
using DataLayer;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        private ISession _session { get; set; }
        public HomeController(ISession session)
        {
            _session = session;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async System.Threading.Tasks.Task Index2()
        {
            IEventStore eventStore = new SqlEventStore("Data Source=DESKTOP-P6BH1QB\\SQLEXPRESS;Initial Catalog=Licenta2018;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //var result =await eventStore.Get(Guid.Parse("bad279dd-4933-45af-a75b-3267747e83e8"), -1);
            //var x = 5;
            var ev = new TopicCreatedEvent(Guid.Parse("bcd279dd-4933-45af-a75b-3267747e83e8"), typeof(Topic), "Gabi","","",DateTime.Now);
            List<IEvent> eventList = new List<IEvent>();
            eventList.Add(ev);
            eventStore.Save<Topic>(eventList);
        }

        public int  CreateTask()
        {
            var taskCommandHandler = new TaskCommandHandler(_session);
            var taskCreatedCommand = new TaskCreatedCommand("gabi", "ado.net", "Learn parameter injection",
                null, 4);
            taskCommandHandler.Handle(taskCreatedCommand);
            return 0;
        }
        public int UpdateTask()
        {
            var taskCommandHandler = new TaskCommandHandler(_session);
            var taskUpdateCommand = new TaskUpdatedCommand(Guid.Parse("912B5B61-1D0B-4142-899D-C686240DC37E"), "biga", "", "", null, 4);
            taskCommandHandler.Handle(taskUpdateCommand);
            return 0;
        }

        public int CreateTopic()
        {
            var topicCommandHandler = new TopicCommandHandler(_session);
            var topicCreatedCommand = new TopicCreatedCommand("use ado.net","for efficiency","gabI");
            topicCommandHandler.Handle(topicCreatedCommand);
            return 0;
        }
        public int UpdateTopic()
        {
            var topicCommandHandler = new TopicCommandHandler(_session);
            var topicCreatedCommand = new TopicUpdatedCommand(Guid.Parse("6334E291-B79A-4592-B6AB-91185EBC2AAD"),"igab","","");
            topicCommandHandler.Handle(topicCreatedCommand);
            return 0;
        }

        public int NewReply()
        {
            var topicCommandHandler = new TopicCommandHandler(_session);
            var topicCreatedCommand = new NewReplyCommand(Guid.Parse("6334E291-B79A-4592-B6AB-91185EBC2AAD"), "gabi", "");
            topicCommandHandler.Handle(topicCreatedCommand);
            return 0;
        }

        public int UpdateReply()
        {
            var topicCommandHandler = new TopicCommandHandler(_session);
            var topicCreatedCommand = new ReplyUpdatedCommand(Guid.Parse("6334E291-B79A-4592-B6AB-91185EBC2AAD"), Guid.Parse("6334E291-B79A-4592-B6AB-91185EBC2AAD"), "abig", "");
            topicCommandHandler.Handle(topicCreatedCommand);
            return 0;
        }


        public int CompleteTask()
        {
            var taskCommandHandler = new TaskCommandHandler(_session);
            var taskCreatedCommand = new TaskCompletedCommand(Guid.Parse("912B5B61-1D0B-4142-899D-C686240DC37E"),true,"abig");
            taskCommandHandler.Handle(taskCreatedCommand);
            return 0;
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
