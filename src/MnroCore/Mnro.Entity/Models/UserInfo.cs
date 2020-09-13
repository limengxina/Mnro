using System;
using System.Collections.Generic;

namespace Mnro.Entity.Models
{
    public partial class UserInfo
    {
        public Guid Id { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Remark { get; set; }
    }
}
