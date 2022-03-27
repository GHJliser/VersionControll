using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AP.Model.BO
{
    public class Customer
    {
        public int Id { get; set; }
        [DbParameter]
        public string? Name { get; set; }
        [DbParameter]
        public int? Age { get; set; }
        [DbParameter]
        public string? Memo { get; set; }
    }
}
