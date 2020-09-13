using System;
using System.Collections.Generic;
using System.Text;

namespace Mnro.Entity.Extenum
{
    public class DbConnOptions
    {
        public string WriteConnection { get; set; }
        public List<string> ReadConnectionList { get; set; }
    }
}
