using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using SimpleOrder.Business.Models;


namespace SimpleOrder.Business.Repository
{
    public  class GenericRepository<T> :
   IGenericRepository<T>
        where T : class
    {

        public GenericRepository(MyStoreContext context)
        {
            _entities = context;
        } 
        private MyStoreContext _entities;
        public MyStoreContext db
        {

            get { return _entities; }
            set { _entities = value; }
        }



        public virtual List<T> GetAll()
        {

            IQueryable<T> query = _entities.Set<T>();
            return query.ToList();
        }

        public List<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {

            IQueryable<T> query = _entities.Set<T>().Where(predicate);
            return query.ToList();
        }
        public virtual void Attach(T entity)
        {
            _entities.Set<T>().Attach(entity);
        }

        public virtual bool Add(T entity)
        {
            _entities.Set<T>().Add(entity);
            return true;
        }

        public virtual bool Delete(T entity)
        {
            _entities.Set<T>().Remove(entity);
            return true;
        }

        public virtual bool Edit(T entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
            return true;
        }

        public virtual bool Save()
        {
            _entities.SaveChanges();
            return true;
        }

        public virtual bool SaveChanges(T entity)
        {
            if (_entities.Entry(entity).State == EntityState.Detached)
            {
                _entities.Set<T>().Attach(entity);
            }
            _entities.Entry(entity).State = EntityState.Modified;
            _entities.SaveChanges();
            return true;
        }
        public virtual T FindById(int id)
        {
           return  _entities.Set<T>().Find(id);
        }

    }
}
