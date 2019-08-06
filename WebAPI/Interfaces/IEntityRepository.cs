using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace WebAPI.Interfaces
{
    public interface IEntityRepository<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll();
        bool Add(TEntity entity);
        bool Delete(int entityId);
        bool Update(TEntity entity);
    }
}