using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Queries;
using Services.Queries.TopicView;
using WebApi.Models.Statistics;
using WebApi.Models.TemporalStatistics;

namespace WebApi.Controllers
{
    public class StatisticsController : Controller
    {
        private IViewSincronizor _viewSincronizor;

        public StatisticsController(IViewSincronizor viewSincronizer)
        {
            _viewSincronizor = viewSincronizer;
        }

        public async Task<IActionResult> LoggedHoursByGrade()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var loggedHours = new LoggedHoursByGrade();

            foreach (var row in result.GradesStatistics) {
                loggedHours.LoggedHours.Add(row.Grade, row.LoggedHours);
            }

            return View(loggedHours);
        }

        public async Task<IActionResult> CompletedTasksByGrade()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var completedTasks = new CompletedTasksByGrade();

            foreach (var row in result.GradesStatistics)
            {
                completedTasks.CompletedTasks.Add(row.Grade, row.CompletedTasks);
            }

            return View(completedTasks);
        }

        public async Task<IActionResult> NumberOfRepliesByGrade()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var numberOfReplies = new NumberOfRepliesByGrade();

            foreach (var row in result.GradesStatistics)
            {
                numberOfReplies.NumberOfReplies.Add(row.Grade, row.NumberOfReplies);
            }

            return View(numberOfReplies);
        }

        public async Task<IActionResult> StartedTasksByGrade()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var startedTasks = new StartedTasksByGrade();

            foreach (var row in result.GradesStatistics)
            {
                startedTasks.StartedTasks.Add(row.Grade, row.StartedTasks);
            }

            return View(startedTasks);
        }

        public async Task<IActionResult> StartedTopicsByGrade()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var startedTopics = new StartedTopicsByGrade();

            foreach (var row in result.GradesStatistics)
            {
                startedTopics.StartedTopics.Add(row.Grade, row.StartedTopics);
            }

            return View(startedTopics);
        }


        public async Task<IActionResult> LoggedHoursTemporalStatistics()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var loggedHours = new LoggedHoursByDate();

            foreach (var row in result.GradesStatistics)
            {
                loggedHours.LoggedHours.Add(new DateTime(), row.LoggedHours);
            }

            return View(loggedHours);
        }

        public async Task<IActionResult> CompletedTasksTemporalStatistics()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var completedTasks = new CompletedTasksByDate();

            foreach (var row in result.GradesStatistics)
            {
                completedTasks.CompletedTasks.Add(new DateTime(), row.CompletedTasks);
            }

            return View(completedTasks);
        }

        public async Task<IActionResult> NumberOfRepliesTemporalStatistics()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var numberOfReplies = new NumberOfRepliesByDate();

            foreach (var row in result.GradesStatistics)
            {
                numberOfReplies.NumberOfReplies.Add(new DateTime(), row.NumberOfReplies);
            }

            return View(numberOfReplies);
        }

        public async Task<IActionResult> StartedTasksTemporalStatistics()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var startedTasks = new StartedTasksByDate();

            foreach (var row in result.GradesStatistics)
            {
                startedTasks.StartedTasks.Add(new DateTime(), row.StartedTasks);
            }

            return View(startedTasks);
        }

        public async Task<IActionResult> StartedTopicsTemporalStatistics()
        {
            var queryHandler = new GetStatisticsQueryHandler(_viewSincronizor);
            var result = await queryHandler.HandleAsync(new GetStatisticsQuery());
            var startedTopics = new StartedTopicsByDate();

            foreach (var row in result.GradesStatistics)
            {
                startedTopics.StartedTopics.Add(new DateTime(), row.StartedTopics);
            }

            return View(startedTopics);
        }

    }
}