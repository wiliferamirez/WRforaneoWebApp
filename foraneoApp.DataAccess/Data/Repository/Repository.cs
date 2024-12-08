using System.Linq.Expressions;
using System.Threading.Tasks;
using foraneoApp.DataAccess.Data.Repository.IRepository;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace foraneoApp.DataAccess.Data.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    protected readonly DbContext Context;
    internal DbSet<T> dbSet;

    public Repository(DbContext context)
    {
        Context = context;
        this.dbSet = context.Set<T>();
    }
    
    public void Add(T entity)
    {
        dbSet.Add(entity);
    }

    public T Get(int id)
    {
        var entity = dbSet.Find(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"No entity of type {typeof(T).Name} with the ID {id} found.");
        }
        return entity;
    }


    public IEnumerable<T> GetAll(
        Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;

        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (includeProperties is not null)
        {
            foreach (var includeProperty in includeProperties.Split(new char[]{','}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
        }

        if (orderBy is not null)
        {
            return orderBy(query).ToList();
        }
        
        return query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null,
        string? includeProperties = null)
    {
        IQueryable<T> query = dbSet;
        if (filter is not null)
        {
            query = query.Where(filter);
        }

        if (includeProperties is not null)
        {
            query = query.Include(includeProperties);
        }

        return query.FirstOrDefault();
    }

    public void Remove(T entity)
    {
        dbSet.Remove(entity);
    }

    public void Remove(int id)
    {
        T entityToRemove = dbSet.Find(id);
    }
}