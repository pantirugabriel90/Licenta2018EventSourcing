using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRSlite.Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Commands.Task;
using Services.Queries.TaskListView;
using Services.Queries.TaskView;
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

        public async Task<ActionResult> Index()
        {
            var queryHandler = new GetTaskListQueryHandler();
            var result = await queryHandler.HandleAsync(new GetTaskListQuery());
            return View(result.TaskList);
        }

        public async  Task<ActionResult> Details(Guid id)
        {
            var queryHandler = new GetTaskQueryHandler();
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
                createTaskCommand.IssuedBy = "Pantiru Gabriel";
                var taskCommandHandler = new TaskCommandHandler(_session);
                await taskCommandHandler.Handle(createTaskCommand);

                return RedirectToAction(nameof(Index));
            }
            return View(createTaskCommand);
        }

        public async Task<ActionResult> UpdateTask(Guid id)
        {
            var queryHandler = new GetTaskQueryHandler();
            var task = await queryHandler.HandleAsync(new GetTaskQuery { AggregateId = id });
            var model = new UpdateTaskCommand
            {
                Title = task.Title,
                AggregateId = task.Id,
                Content = task.Content,
                CompletedStatus = task.CompletedStatus,
                Hours = task.Hours,
                LoggedHours = task.LoggedHours,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateTask(UpdateTaskCommand updateTask)
        {
            if (ModelState.IsValid)
            {
                updateTask.IssuedBy = "Pantiru Gabriel";
                var taskCommandHandler = new TaskCommandHandler(_session);
                await taskCommandHandler.Handle(updateTask);

                return RedirectToAction(nameof(Index));
            }

            return View(updateTask);

        }

        public async Task<ActionResult> ChangeTaskStatus(Guid id)
        {

            var taskCommandHandler = new TaskCommandHandler(_session);
            var taskCreatedCommand = new ChangeTaskStatusCommand(id, "abig");
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