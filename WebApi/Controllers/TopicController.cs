using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Topic;
using WebApplication3.Models;
using CQRSlite.Domain;
using Services.Queries.TaskView;
using Services.Queries.TopicListView;
using Services.Queries.TopicView;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TopicController : Controller
    {
        private ISession _session { get; }

        public TopicController(ISession session)
        {
            _session = session;
        }
        // GET: Topic
        public async Task<ActionResult> Index()
        {
            var queryHandler = new GetTopicListQueryHandler();
            var result = await queryHandler.HandleAsync(new GetTopicListQuery());
            return View(result.TopicList);
        }

        // GET: Topic/Details/5
        public async Task<ActionResult>  Details(Guid id)
        {

            var queryHandler = new GetTopicQueryHandler();
            var result = await queryHandler.HandleAsync(new GetTopicQuery { AggregateId = id });
            return View(result);
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
                createTopicCommand.IssuedBy = User.Identity.Name;
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(createTopicCommand);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        
        // GET: Topic/Edit/5
        public async Task<ActionResult> UpdateTopic(Guid id)
        {
            ViewBag.AggregateId = id;
            var queryHandler = new GetTopicQueryHandler();
            var result = await queryHandler.HandleAsync(new GetTopicQuery { AggregateId = id });
            var model= new UpdateTopicCommand
            {
                AggregateId = result.Id,
                Content = result.Content,
                IssuedBy = result.IssuedBy,
                Title = result.Title,
                UpdateDate = result.Date
            };
            return View(model);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateTopic(UpdateTopicCommand updateTopicCommand)
        {
            if (ModelState.IsValid)
            {
                updateTopicCommand.IssuedBy = User.Identity.Name;
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(updateTopicCommand);

                return RedirectToAction("Details", new { id = updateTopicCommand.AggregateId });
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
                addNewReplyCommand.IssuedBy = User.Identity.Name;
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(addNewReplyCommand);

                return RedirectToAction("Details", new { id = addNewReplyCommand.AggregateId });

            }
            return View();
        }

        public async Task<ActionResult> UpdateReply(Guid id, Guid replyId)
        {
            ViewBag.AggregateId = id;
            ViewBag.ReplyId = replyId;

            ViewBag.AggregateId = id;
            var queryHandler = new GetTopicQueryHandler();
            var result = (await queryHandler.HandleAsync(new GetTopicQuery { AggregateId = id })).Replies.FirstOrDefault(r=>r.Id==replyId);
            var model = new UpdateReplyCommand()
            {
                AggregateId = id,
                Content = result.Content,
                IssuedBy = result.IssuedBy,
                Date = result.Date,
                ReplyId = result.Id
            };
            return View(model);
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateReply(UpdateReplyCommand updateReplyCommand)
        {
            if (ModelState.IsValid)
            {
                updateReplyCommand.IssuedBy = User.Identity.Name;
                var topicCommandHandler = new TopicCommandHandler(_session);
                await topicCommandHandler.Handle(updateReplyCommand);

                return RedirectToAction("Details", new { id = updateReplyCommand.AggregateId });

            }
            return View();
        }


    }
}