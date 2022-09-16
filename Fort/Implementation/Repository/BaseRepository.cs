using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Fort.Context;
using Fort.Model;
using Fort.Interfaces.Repository;
using Fort.Contract;
using Fort.Identity;

namespace Fort.Implementation
{
    public abstract class BaseRepository<T>:IBaseRepository<T> where T:base_Entity,new()
    {
        protected ApplicationContext _context;

        protected BaseRepository(ApplicationContext context)
        {
            _context = context ;
        }



        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }


        

      
        public  void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }


      



        public IList<T> Query(Expression<Func<T, bool>> expression)
        {

            var entity = _context.Set<T>().Where(expression).AsQueryable(). ToList();
            return entity;
        }
            

     

       
        
        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }






        public IList<T> GetByListOfId(IList<int> ids)
        {
            var entity = _context.Set<T>().Where(j => ids.Contains(j.Id));
            return entity.ToList();
        }

      



        public IList<T> GetAll()
        {
            var entity = _context.Set<T>().ToList();
            return entity;
        }


      

        public bool Exist(Expression<Func<T, bool>> expression)
        {
            var entity = _context.Set<T>().Any(expression);
            return entity;
        }

      public T    GetByExpression(Expression<Func<T, bool>> expression)
        {
            var entity= _context.Set<T>().SingleOrDefault(expression);
            return entity;
        }

        public IList<T> GetByExpressions(Expression<Func<T, bool>> expression)
        {
            var entities = _context.Set<T>().Where(expression);
            return entities.ToList();
        }

      

     
    }
}
