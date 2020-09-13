using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mnro.Entity.Models;

namespace Mnro.Entity.Extenum
{
    public static class ContextExtension
    {
        public static DbContext ToEFCoreContext(this DbContext context, string conn)
        {
            if (context is BlogMnContext)
            {
                BlogMnContext efCoreContext = (BlogMnContext)context;
                efCoreContext.strConn = conn;
                return context;
            }
            else
            {
                throw new Exception("context error");
            }
        }

    }
}
