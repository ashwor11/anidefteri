﻿using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TContext, TEntity> : IRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : class, IEntity 
        where TContext : DbContext
    {
        protected TContext Context { get; }
        public EfRepositoryBase(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable();
            queryable = queryable.Where(predicate);
            if(include != null) queryable = include(queryable);
            return queryable.FirstOrDefault();
        }

        public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy, int size = 10, int index = 0, bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable();
            if(enableTracking != true) queryable = queryable.AsNoTracking();
            if(predicate != null) queryable = queryable.Where(predicate);
            if(include!=null) queryable = include(queryable);
            if(orderBy!=null) queryable = orderBy(queryable);
            return queryable.ToPaginate(index, size);
        }

        public TEntity Create(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;

        }

        public TEntity Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            Context.SaveChanges();
            return entity;
        }

        public IQueryable<TEntity> Query()
        {
            return Context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,
                                                                            object>>? include = null, bool enableTracking = true, CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable();
            if (!enableTracking) queryable.AsNoTracking();
            queryable =  queryable.Where(predicate);
            if(include != null) queryable = include(queryable);
            return await queryable.FirstOrDefaultAsync(cancellationToken);

        }

        public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
                                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, int size = 10, int index = 0, bool enableTracking = true,
                                               CancellationToken cancellationToken = default)
        {
            IQueryable<TEntity> queryable = Query().AsQueryable();
            if(!enableTracking) queryable.AsNoTracking();
            if(include != null) queryable = include(queryable);
            if (predicate != null) queryable = queryable.Where(predicate);
            if (orderBy != null) queryable = orderBy(queryable);

            return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);



        
            
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }  

        



        
    }
}
