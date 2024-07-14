using Application.Repositories.Abstract;
using Domain;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories.Concrete
{
    public class EfGenericRepository<T, TId, TContext> : IGenericRepository<T, TId>, IAsyncGenericRepository<T, TId>
        where T : BaseEntity<TId>, new()
        where TContext : DbContext
    {
        private readonly TContext _context;
        public EfGenericRepository(TContext context)
        {
            this._context = context;
        }

        public async Task<T> AddAsync(T t, CancellationToken cancellationToken = default)
        {
            t.CreatedDate = DateTime.Now;
            await _context.AddAsync(t, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return t;
        }

        public void Delete(T t)
        {
            t.DeletedDate = DateTime.Now;
            // Hard Delete - Soft Delete
            // Context.Remove(entity); // Hard Delete
            _context.Update(t);
            _context.SaveChanges();
        }

        public async Task<T> DeleteAsync(T t)
        {
            t.DeletedDate = DateTime.Now;
            _context.Entry(t).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return t;
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().Where(t => !t.DeletedDate.HasValue).ToList();
        }

        public async Task<List<T>> GetAllAsync()
        {
            List<T> t = await _context.Set<T>().Where(t => !t.DeletedDate.HasValue).ToListAsync();
            return t;
        }

        public T GetById(TId id)
        {
            return _context.Set<T>().FirstOrDefault(t => t.Id.Equals(id) && !t.DeletedDate.HasValue);
        }

        public async Task<T> GetByIdAsync(TId id)
        {
            var brand = await _context.Set<T>().FindAsync(id);
            return brand;
        }

        public T Insert(T t)
        {
            t.CreatedDate = DateTime.Now;
            _context.Add(t);
            _context.SaveChanges();
            return t;
        }

        public void Update(T t)
        {
            t.UpdatedDate = DateTime.Now;
            _context.Update(t);
            _context.SaveChanges();
        }

        public async Task<T> UpdateAsync(T t)
        {
            t.UpdatedDate = DateTime.Now; // Güncelleme tarihini ayarla

            _context.Update(t); // Nesneyi güncelle
            await _context.SaveChangesAsync(); // Değişiklikleri veritabanına kaydet

            return t;
        }
    }


}
