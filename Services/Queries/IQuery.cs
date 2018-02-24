using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries
{
    public interface IQuery<out TResult> where TResult : IQueryResult
    {

    }
}
