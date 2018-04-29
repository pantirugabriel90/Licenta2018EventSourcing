using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Services.Queries.TaskListView;

namespace Services.Queries.TaskView
{
    public class GetTaskQueryHandler: IQueryHandler<GetTaskQuery, GetTaskQueryResult>
    {

        private IViewSincronizor _viewSincronizer;
        public GetTaskQueryHandler(IViewSincronizor viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
        }
        public async Task<GetTaskQueryResult> HandleAsync(GetTaskQuery query)
        {

            _viewSincronizer.Sincornize();

            var context = new ApplicationContext();

           var task = context.Tasks.FirstOrDefault(t => t.Id == query.AggregateId);
            return new GetTaskQueryResult
            {
                Title =task.Title,
                Id = task.Id,
                CompletedStatus = task.CompletedStatus,
                Content = task.Content,
                Date = task.Date,
                Hours = task.Hours,
                LoggedHours = task.LoggedHours,
                Tags= task.Tags,
                IssuedBy = task.IssuedBy
            };
        }
    }
}
