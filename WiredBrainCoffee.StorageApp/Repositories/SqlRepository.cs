using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.StorageApp.Entities;

namespace WiredBrainCoffee.StorageApp.Repositories
{
    public class SqlRepository<TItem> where TItem : class, IEntity

    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TItem> _dbSet;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TItem>();
        }

        public TItem GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TItem item)
        {
            //item.Id=_dbSet.Count + 1;
            item.Id = _dbSet.Any()
                ? _dbSet.Max(item => item.Id) + 1
                : 1;
            _dbSet.Add(item);
        }

        public void Remove(TItem item)
        {
            _dbSet.Remove(item);
        }

        public void Save()
        {
            foreach (var item in _dbSet)
            {
                Console.WriteLine(item);
            }
        }
    }

}
