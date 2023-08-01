using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SimpleProjectContext : DbContext
    {
        public SimpleProjectContext(DbContextOptions<SimpleProjectContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
