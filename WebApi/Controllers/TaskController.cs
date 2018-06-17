using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Task;
using Services.Queries;
using Services.Queries.TaskListView;
using Services.Queries.TaskView;
using WebApi.Models;
using WebApplication3.Models;

namespace WebApi.Controllers
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class TaskController : Controller
    {
        private ISession _session { get; }
        private IViewSincronizor _viewSincronizor { get; }

        public TaskController(ISession session,IViewSincronizor viewSincronizer)
        {
            _viewSincronizor = viewSincronizer;
            _session = session;
        }

        public async Task<ActionResult> Index()
        {
            var queryHandler = new GetTaskListQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetTaskListQuery());
            return View(result.TaskList);
        }

       
        public async  Task<ActionResult> Details(Guid id)
        {
            var queryHandler = new GetTaskQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetTaskQuery{AggregateId = id});
            return View(result);
        }

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
                createTaskCommand.IssuedBy = User.Identity.Name;
                var taskCommandHandler = new TaskCommandHandler(_session);
                await taskCommandHandler.Handle(createTaskCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(createTaskCommand);
        }

        public async Task<ActionResult> UpdateTask(Guid id)
        {
            ViewBag.AggregateId = id;
            var queryHandler = new GetTaskQueryHandler(_viewSincronizor);
            var task = await queryHandler.HandleAsync(new GetTaskQuery { AggregateId = id });
            var model = new UpdateTaskCommand
            {
                Title = task.Title,
                AggregateId = task.Id,
                Content = task.Content,
                CompletedStatus = task.CompletedStatus,
                Hours = task.Hours,
                LoggedHours = task.LoggedHours,
                IssuedBy = User.Identity.Name
            };
            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateTask(UpdateTaskCommand updateTaskCommand)
        {
            if (ModelState.IsValid)
            {
                updateTaskCommand.IssuedBy = User.Identity.Name;
                var taskCommandHandler = new TaskCommandHandler(_session);
                await taskCommandHandler.Handle(updateTaskCommand);

                return RedirectToAction(nameof(Index));
            }

            return View(updateTaskCommand);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LogHours(LogTaskHoursCommand logHoursCommand)
        {
            if (ModelState.IsValid)
            {
                logHoursCommand.IssuedBy = User.Identity.Name;
                var taskCommandHandler = new TaskCommandHandler(_session);
                await taskCommandHandler.Handle(logHoursCommand);
            }

            return RedirectToAction(nameof(Details), new { id = logHoursCommand.AggregateId });

        }



        public async Task<ActionResult> CompleteTask(Guid id, bool redirectToTaskList)
        {
            var taskCommandHandler = new TaskCommandHandler(_session);
            var taskCreatedCommand = new CompleteTaskCommand(id, User.Identity.Name);
            await taskCommandHandler.Handle(taskCreatedCommand);

            if (redirectToTaskList)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Details), new { id });

        }

        public async Task<ActionResult> ReopenTask(Guid id, bool redirectToTaskList)
        {
            var taskCommandHandler = new TaskCommandHandler(_session);
            var taskCreatedCommand = new ReopenTaskCommand(id, User.Identity.Name);
            await taskCommandHandler.Handle(taskCreatedCommand);

            if (redirectToTaskList)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Details), new { id });

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