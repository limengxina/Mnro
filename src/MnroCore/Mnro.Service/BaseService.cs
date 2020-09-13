using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using Mnro.Entity.Extenum;
using Mnro.Interface;

namespace Mnro.Service
{
    public class BaseService : IBaseService
    {
        private IDbContextFactory _DbContextfactory = null;

        protected DbContext _context = null;

        public BaseService(IDbContextFactory factory)
        {
            this._DbContextfactory = factory;
        }

        public T Find<T>(Guid id, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class
        {
            _context = _DbContextfactory.CreateContext(writeAndRead);

            return this._context.Set<T>().Find(id);
        }

        public IQueryable<T> Query<T>(WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T:class
        {
            _context = _DbContextfactory.CreateContext(writeAndRead);

            return this._context.Set<T>();
        }

        public T Insert<T>(T t) where T:class
        {
            this._context.Set<T>().Add(t);
            return t;
        }

        public void Delete<T>(Guid Id) where T : class
        {
            T t = this.Find<T>(Id);
            if (t == null) throw new Exception("t is null");
            this._context.Set<T>().Remove(t);
        }

        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this._context.Set<T>().Attach(t);
            this._context.Set<T>().Remove(t);
        }

    }
}
