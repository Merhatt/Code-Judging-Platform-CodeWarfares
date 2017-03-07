using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeWarfares.Data.Contracts
{
    /// <summary>
    /// Repository pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> All();

        T GetById<TId>(TId id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Delete<TId>(TId id);

        void Detach(T entity);

        int SaveChanges();
    }
}
