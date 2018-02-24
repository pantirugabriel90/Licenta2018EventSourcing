using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries
{

    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult> where TResult : IQueryResult
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
