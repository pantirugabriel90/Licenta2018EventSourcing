using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApi.Controllers
{
    public class TopicController : Controller
    {
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
        public ActionResult Create(TopicViewModel collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Topic/Edit/5
        public ActionResult UpdateTopic(Guid id)
        {
            ViewBag.IdData = id;
            return View();
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTopic(int id, TopicViewModel collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult NewReply(Guid id)
        {
            ViewBag.IdData = id;

            return View();
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewReply(ReplyViewModel collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult UpdateReply(Guid id,Guid replyId)
        {
            ViewBag.Id = id;
            ViewBag.ReplyId = replyId;
            return View();
        }

        // POST: Topic/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateReply(ReplyViewModel collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        
    }
}