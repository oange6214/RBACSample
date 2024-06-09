﻿namespace RBACSample.Infrastructures.Repository;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);

    Task<IEnumerable<T>> GetAllAsync();

    Task AddAsync(T entity);

    void Update(T entity);

    void Remove(T entity);

    Task<int> SaveChangesAsync();
}