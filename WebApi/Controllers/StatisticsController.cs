using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Queries;
using Services.Queries.TopicView;
using WebApi.Models.Statistics;

namespace WebApi.Controllers
{
    public class StatisticsController : Controller
    {
        private ISession _session { get; }
        private IViewSincronizor _viewSincronizor;

        public StatisticsController(ISession session, IViewSincronizor viewSincronizer)
        {
            _viewSincronizor = viewSincronizer;
            _session = session;
        }

        public async Task<IActionResult> CompletedTasksStatistics()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            return View(result.GradesStatistics);
        }

        public async Task<IActionResult> LoggedHours()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var loggedHours = new LoggedHours();

            foreach (var row in result.GradesStatistics) {
                loggedHours.LoggedHoursByGrade.Add(row.Grade, row.LoggedHours);
            }

            return View(loggedHours);
        }

        public async Task<IActionResult> CompletedTasks()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var completedTasks = new CompletedTasks();

            foreach (var row in result.GradesStatistics)
            {
                completedTasks.CompletedTasksByGrade.Add(row.Grade, row.CompletedTasks);
            }

            return View(completedTasks);
        }

        public async Task<IActionResult> NumberOfReplies()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var numberOfReplies = new NumberOfReplies();

            foreach (var row in result.GradesStatistics)
            {
                numberOfReplies.NumberOfRepliesByGrade.Add(row.Grade, row.NumberOfReplies);
            }

            return View(numberOfReplies);
        }

        public async Task<IActionResult> StartedTasks()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var startedTasks = new StartedTasks();

            foreach (var row in result.GradesStatistics)
            {
                startedTasks.StartedTasksByGrade.Add(row.Grade, row.StartedTasks);
            }

            return View(startedTasks);
        }

        public async Task<IActionResult> StartedTopics()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var startedTopics = new StartedTopics();

            foreach (var row in result.GradesStatistics)
            {
                startedTopics.StartedTopicsByGrade.Add(row.Grade, row.StartedTopics);
            }

            return View(startedTopics);
        }

    }
}