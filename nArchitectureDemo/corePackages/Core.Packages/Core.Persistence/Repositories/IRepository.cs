﻿using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity, TEntityId>:IQuery<TEntity>
        where TEntity : Entity<TEntityId>
    {

       TEntity? Get(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
       );


        Paginate<TEntity> GetList(

             Expression<Func<TEntity, bool>>? predicate = null,
             Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
             int index = 0,
             int size = 10,
             bool withDeleted = false,
             bool enableTracking = true,
             CancellationToken cancellationToken = default

         );

        Paginate<TEntity> GetListByDinamic(
           DynamicQuery dynamic,
           Expression<Func<TEntity, bool>>? predicate = null,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           int index = 0,
           int size = 10,
           bool withDeleted = false,
           bool enableTracking = true,
           CancellationToken cancellationToken = default
           );


         bool Any(
             Expression<Func<TEntity, bool>> predicate = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
          );


        TEntity Add(TEntity entity);

        ICollection<TEntity> AddRange(ICollection<TEntity> entities);

        TEntity Update(TEntity entity);

        ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);

        //permanent; Veriyi kalıcı mi sileyiim yoksa silindi olarak mı işaretleyeyim.
        TEntity Delete(TEntity entity, bool permanet = false);

        ICollection<TEntity> DeleteRange(ICollection<TEntity> entities, bool permanet = false);

    }
}
