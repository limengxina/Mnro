using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Mnro.Entity.Extenum
{
    public interface IDbContextFactory
    {
        DbContext CreateContext(WriteAndReadEnum writeAndRead);
    }
}
