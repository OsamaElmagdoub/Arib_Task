﻿
using Arib_Task.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Arib_Task.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        
                => await _dbSet.ToListAsync();
        
        
        public async Task<T> GetById(int id)
        
            => await _dbSet.FindAsync(id);
        public async Task Add(T entity) 
            
            => await _dbSet.AddAsync(entity); 

        public void Update(T entity) 

            => _dbSet.Update(entity);
        
        public void Delete(T entity)
        
            => _dbSet.Remove(entity);


        public async Task SaveChanges() => await _context.SaveChangesAsync();

        

    }

}
