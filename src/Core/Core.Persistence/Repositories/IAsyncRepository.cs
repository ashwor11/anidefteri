﻿using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IAsyncRepository<T> : IQuery<T> where T : IEntity
    {
        Task<T>? GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include, bool enableTracking = true, CancellationToken cancellationToken = default);

        Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate,
                  Func<IQueryable<T>, IIncludableQueryable<T, object>>? include,
                  Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy,
                  int size = 10,
                  int index = 0,
                  bool enableTracking = true,
                  CancellationToken cancellationToken = default);

        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
    }
}
