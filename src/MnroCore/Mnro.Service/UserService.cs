using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Mnro.Entity.Extenum;
using Mnro.Interface;

namespace Mnro.Service
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IDbContextFactory factory) : base(factory)
        {

        }
    }
}
