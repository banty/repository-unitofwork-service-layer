using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SimpleOrder.Business.Repository
{
    public interface IGenericRepository<T> where T : class
    {

        List<T> GetAll();
        List<T> FindBy(Expression<Func<T, bool>> predicate);
        bool Add(T entity);
        bool Delete(T entity);
        bool Edit(T entity);
        bool Save();
        bool SaveChanges(T entity);
        T FindById(int id);


    }
}
