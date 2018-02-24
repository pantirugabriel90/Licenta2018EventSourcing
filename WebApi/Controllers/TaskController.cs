using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSlite.Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Task;
using WebApi.Models;
using WebApplication3.Models;

namespace WebApi.Controllers
{
    public class TaskController : Controller
    {
        private ISession _session { get; }

        public TaskController(ISession session)
        {
            _session = session;
        }
        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = new List<TaskListViewModel>
            {
                new TaskListViewModel
                {
                    Completed = false,
                    Title = "Entity framework",
                    Id = Guid.NewGuid()
                },
                new TaskListViewModel
                {
                    Completed = true,
                    Title = "Ado.net",
                    Id = Guid.NewGuid()
                }
            };
            return View(tasks);
        }

        // GET: Tasks/Details/5 
        public ActionResult Details(Guid id)
        {
            var task = new TaskViewModel
            {
                CompletedStatus = true,
                Content = "learn ado.net",
                Date = DateTime.UtcNow,
                Hours = 8,
                LoggedHours = 4,
                Id = Guid.NewGuid(),
                Title = "ado.net"

            };
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content,Hours,Date,Completed")] CreateTaskCommand createTaskCommand)
        {
            if (ModelState.IsValid)
            {
                createTaskCommand.IssuedBy = "Pantiru Gabriel";
                var taskCommandHandler = new TaskCommandHandler(_session);
                await taskCommandHandler.Handle(createTaskCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(createTaskCommand);
        }

        // GET: Tasks/Edit/5
        public ActionResult UpdateTask(Guid id)
        {
            ViewBag.IdData = id;
            return View();
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTask(TaskViewModel task)
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

        //[HttpPut]
        public async Task<ActionResult> ChangeTaskStatus(Guid id)
        {

            var taskCommandHandler = new TaskCommandHandler(_session);
            var taskCreatedCommand = new TaskStatusChangedCommand(id, "abig");
            await taskCommandHandler.Handle(taskCreatedCommand);
            
            return RedirectToAction(nameof(Index));
        }
        
        public ActionResult Delete(Guid id)
        {
            return RedirectToAction(nameof(Index));
        }


        //// POST: Tasks/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}