﻿using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Implementation
{
    public abstract class BaseRepository<T>:IRepository<T> where T : class
    {
        private readonly DbSet<T> _set;
        private readonly DbContext _dbContext;
        public BaseRepository(DbContext context)
        {
            _dbContext = context;
            _set = context.Set<T>(); 
        }

        public void Create(T item)
        {
            _set.Add(item);
        }

        public void Delete(int id)
        {
            var item = Get(id);
            _set.Remove(item);
        }

        public IEnumerable<T> Find(
            Func<T, bool> predicate)
        {
            return
                _set.Where(predicate)
                    .ToList();
        }

        public T Get(int id)
        {
            return _set.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _set.ToList();
        }

        public void Update(T item)
        {
            _dbContext.Entry(item).State = EntityState.Modified;
        }
    }
}
