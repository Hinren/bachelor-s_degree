using SignLanguage.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignLanguage.EF.Repository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetOverview(Func<T, bool> predicate = null);
        T GetDetail(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
    }
}
