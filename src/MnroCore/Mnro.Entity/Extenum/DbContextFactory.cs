using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Mnro.Entity.Extenum
{
    public class DbContextFactory : IDbContextFactory
    {
        private DbContext _DbContext = null;

        private DbConnOptions dbconnOptions = null;
        public DbContextFactory(DbContext context,IOptionsMonitor<DbConnOptions> options)
        {
            _DbContext = context;
            dbconnOptions = options.CurrentValue;
        }

        public DbContext CreateContext(WriteAndReadEnum writeAndRead)
        {
            string strConn = string.Empty;
            switch (writeAndRead)
            {
                case WriteAndReadEnum.Write:
                    strConn = dbconnOptions.WriteConnection;
                    break;
                case WriteAndReadEnum.Read:
                    strConn = GetPolling();
                    break;
                default:
                    break;
            }
            return _DbContext.ToEFCoreContext(strConn);
        }

        /// <summary>
        /// 随机策略
        /// </summary>
        /// <returns></returns>
        private string GetRandom()
        {
            int index = new Random().Next(0, dbconnOptions.ReadConnectionList.Count);
            return dbconnOptions.ReadConnectionList[index];
        }

        private static int i = 0;
        /// <summary>
        /// 轮询策略
        /// </summary>
        /// <returns></returns>
        private string GetPolling()
        {
            if (i >= dbconnOptions.ReadConnectionList.Count)
            {
                i = 0;
            }
            string conn = dbconnOptions.ReadConnectionList[i];
            i++;
            return conn;
        }

    }
}
