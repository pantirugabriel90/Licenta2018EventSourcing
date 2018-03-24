using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Topic;
using WebApplication3.Models;
using CQRSlite.Domain;

namespace WebApi.Controllers
{
    public class TopicController : Controller
    {
        private ISession _session { get; }

        public TopicController(ISession session)
        {
            _session = session;
        }
        // GET: Topic
        public ActionResult Index()
        {
            var topics = new List<TopicListViewModel>
            {
                new TopicListViewModel
                {
                    Date = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    IssuedBy = "gabi",
                    Title = "ado.net"
                },
                new TopicListViewModel
                {
                    Date = DateTime.UtcNow,
                    Id = Guid.NewGuid(),
                    IssuedBy = "gabi",
                    Title = "entity framework"
                }
            };
            return View(topics);
        }

        // GET: Topic/Details/5
        public ActionResult Details(int id)
        {
            var topic = new TopicViewModel
            {
                Content = "what is ado.net",
                Date = DateTime.UtcNow,
                Id = Guid.NewGuid(),
                IssuedBy = "Gabi",
                Replies = new List<ReplyViewModel>
                {
                    new ReplyViewModel
                    {
                        Content = "first",Date=DateTime.MaxValue,Id = Guid.NewGuid(),IssuedBy = "gabi",ReplyId = Guid.NewGuid()
                    },new ReplyViewModel
                    {
                        Content = "2",Date=DateTime.MaxValue,Id = Guid.NewGuid(),IssuedBy = "gabi",ReplyId = Guid.NewGuid()
                    },new ReplyViewModel
                    {
                        Content = "3",Date=DateTime.MaxValue,Id = Guid.NewGuid(),IssuedBy = "gabi",ReplyId = Guid.NewGuid()
                    },new ReplyViewModel
                    {
                        Content = "4",Date=DateTime.MaxValue,Id = Guid.NewGuid(),IssuedBy = "gabi",ReplyId = Guid.NewGuid()
                    },new ReplyViewModel
                    {
                        Content = "5",Date=DateTime.MaxValue,Id = Guid.NewGuid(),IssuedBy = "gabi",ReplyId = Guid.NewGuid()
                    },new ReplyViewModel
                    {
                        Content = "6",Date=DateTime.MaxValue,Id = Guid.NewGuid(),IssuedBy = "gabi",ReplyId = Guid.NewGuid()
                    }

                },
                Title = "ado.net"

            };
            return View(topic);
        }

        // GET: Topic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Topic/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateTopicCommand createTopicCommand)
        {

            if (ModelState.IsValid)
            {
                createTopicCommand.IssuedBy = "Pantiru Gabriel";
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(createTopicCommand);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        
        // GET: Topic/Edit/5
        public ActionResult UpdateTopic(Guid id)
        {
            ViewBag.AggregateId = id;
            return View();
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateTopic(UpdateTopicCommand updateTopicCommand)
        {
            if (ModelState.IsValid)
            {
                updateTopicCommand.IssuedBy = "Pantiru Gabriel";
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(updateTopicCommand);

                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        //[Route("Topic/AddNewReply/{topicId}")]
        public ActionResult AddNewReply(Guid id)
        {
            ViewBag.AggregateId = id;

            return View();
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewReply(AddNewReplyCommand addNewReplyCommand)
        {
            if (ModelState.IsValid)
            {
                addNewReplyCommand.IssuedBy = "Pantiru Gabriel";
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(addNewReplyCommand);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public ActionResult UpdateReply(Guid id, Guid replyId)
        {
            ViewBag.AggregateId = id;
            ViewBag.ReplyId = replyId;
            return View();
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateReply(UpdateReplyCommand updateReplyCommand)
        {
            if (ModelState.IsValid)
            {
                updateReplyCommand.IssuedBy = "Pantiru Gabriel";
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(updateReplyCommand);

                return RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}