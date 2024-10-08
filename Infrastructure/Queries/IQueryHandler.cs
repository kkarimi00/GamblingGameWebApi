﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}
