using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerLog.Models
{
    public class CustomerLogContext : DbContext
    {
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Log> Logs { get; set; }
    }
}
