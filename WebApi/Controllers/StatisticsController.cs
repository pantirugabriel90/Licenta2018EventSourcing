using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRSlite.Domain;
using Microsoft.AspNetCore.Mvc;
using Services.Queries;
using Services.Queries.TopicView;

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

    }
}