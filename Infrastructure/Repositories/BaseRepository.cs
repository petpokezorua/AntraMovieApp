using ApplicationCore.Contracts.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IRepository<T> where T : class
{
    protected readonly MovieShopDbContext _dbContext;

    public BaseRepository(MovieShopDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public T Insert(T entity)
    {
        _dbContext.Set<T>().Add(entity);
        _dbContext.SaveChanges();
        return entity;
    }

    public T DeleteById(int id)
    {
        var entity = _dbContext.Set<T>().Find(id);
        if (entity != null)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
            return entity;
        }
        return null;
    }

    public T Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        _dbContext.SaveChanges();
        return entity;
    }

    public IEnumerable<T> GetAll()
    {
        return _dbContext.Set<T>().ToList();
    }

    public T GetById(int id)
    {
        return _dbContext.Set<T>().Find(id);
    }
}