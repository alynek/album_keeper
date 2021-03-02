using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repository
{
    public class BaseRepository<T> where T : class
    {
        public DbContext AppDbContext{get; set;} 
        public DbSet<T> Query{get; set;}
        public BaseRepository(Context context)
        {
            this.AppDbContext = context;
            this.Query = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await this.Query.ToListAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            return await this.Query.FindAsync(id);
        }

        public async Task Remove(T item)
        {
            this.Query.Remove(item);
            await this.AppDbContext.SaveChangesAsync();
        }

        public async Task Save(T item)
        {
            this.Query.Add(item);
            await this.AppDbContext.SaveChangesAsync();
        }

        public async Task Update(T item)
        {
            this.Query.Update(item);
            await this.AppDbContext.SaveChangesAsync();
        }
    }
}