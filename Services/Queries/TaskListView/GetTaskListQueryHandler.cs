using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Services.Queries.TaskListView
{
    public class GetTaskListQueryHandler:IQueryHandler<GetTaskListQuery,GetTaskListQueryResult>
    {
        private IViewSincronizor _viewSincronizer;
        public GetTaskListQueryHandler(IViewSincronizor viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
        }
        public async Task<GetTaskListQueryResult> HandleAsync(GetTaskListQuery query)
        {
            _viewSincronizer.Sincornize();

            var context = new ApplicationContext();
            return new GetTaskListQueryResult
            {
                TaskList =   context.TaskList.ToList()
            };
        }
    }
}
