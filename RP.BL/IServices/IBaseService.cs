using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RP.BL.IServices
{
    public interface IBaseService<T> where T : class
    {
        
         /// <summary>
        /// Return entities by filter
        /// </summary>
        /// <param name="where">Expression that represent the filter</param>
        /// <param name="loadDeeperEntites">Array that contain the multiple levels of entities to be loaded </param>
        /// <param name="includes">Expressions that specify the entities to be loaded</param>
        /// <returns></returns>
         IEnumerable<T> Get(Expression<Func<T, bool>> where = null,params Expression<Func<T, object>>[] includes);
         IEnumerable<T> GetAll(params Expression<Func<T, object>>[] includes);
         int Create(T t);
         int Update(T t);
         void Delete(T t);
    }
}