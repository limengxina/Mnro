using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mnro.Entity.Extenum;

namespace Mnro.Interface
{
    public interface IBaseService
    {
        T Find<T>(Guid id, WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class;

        IQueryable<T> Query<T>(WriteAndReadEnum writeAndRead = WriteAndReadEnum.Read) where T : class;

        T Insert<T>(T t) where T : class;

        void Delete<T>(Guid Id) where T : class;

        void Delete<T>(T t) where T : class;

    }
}
