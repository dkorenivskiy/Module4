using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice01
{
    class BaseRepository<T> : IDisposable
        where T : Entity
    {
        private readonly DbContext _dbContext;
        private bool disposedValue;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>()
                .FirstOrDefault(x => x.Id == id);
        }

        public void Remove(T entity)
        {
            if (entity != null)
            {
                RemoveById(entity.Id);
            }
        }

        public void RemoveById(int id)
        {
            var entity = GetById(id);
            if (entity != null)
            {
                _dbContext.Set<T>().Remove(entity);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    _dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~BaseRepository()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
