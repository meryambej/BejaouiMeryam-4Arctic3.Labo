﻿using System.Linq.Expressions;

namespace Examen.ApplicationCore.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> where);
        T GetById(params object[] keyValues);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where = null);
        T Get(Expression<Func<T, bool>> where);
        void Commit();

    }
}
