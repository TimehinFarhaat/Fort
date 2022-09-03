using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Fort.DTOs;
using Microsoft.EntityFrameworkCore;


namespace Fort.Interfaces.Repository
{
    public interface IBaseRepository<T>
    {
        public void   Add(T entity);
     
        public IList<T> Query (Expression<Func<T, bool>> expression);
       

        public void Update (T entity);
        public IList<T> GetByListOfId(IList<int> ids);
        public IList<T> GetAll();
        public IList<T> GetByExpressions (Expression<Func<T, bool>> expression);
        public T GetByExpression(Expression<Func<T,bool>> expression);
       // public T GetByListOfUser(IList<T> users);
        public bool Exist (Expression<Func<T, bool>> expression);
    }
}
