﻿using Examen.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Examen.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext context;

        public UnitOfWork(DbContext ctx)
        {
            context = ctx;
        }

        public IGenericRepository<T> Repository<T>() where T : class
        {
            return new GenericRepository<T>(context);
        }
        public int Save()
        {
            return context.SaveChanges();
        }

        /////////////Disposable/////////////////
        private bool disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


    }
}
