﻿using CleanArchitecture.DataAccess.Models;
using System.Linq.Expressions;


namespace CleanArchitecture.DataAccess.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        IQueryable<T> AsQueryable();

    }
}
