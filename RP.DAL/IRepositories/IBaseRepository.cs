using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RP.DAL.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        /// <summary>
        /// Return All entities
        /// </summary>
        /// <param name="includes">Expressions that specify the entities to be loaded</param>
        /// <returns></returns>
        IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes );
        /// <summary>
        /// Return entities by filter
        /// </summary>
        /// <param name="where">Expression that represent the filter</param>
        /// <param name="includes">Expressions that specify the entities to be loaded</param>
        /// <returns></returns>
        IEnumerable<T> Filter(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] includes);
        int SaveChanges();
    }
}