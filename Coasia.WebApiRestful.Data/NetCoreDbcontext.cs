using Coasia.WebApiRestful.Domain.Entitys;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coasia.WebApiRestful.Data
{
    public class NetCoreDbcontext:DbContext
    {
        public NetCoreDbcontext( DbContextOptions<NetCoreDbcontext> options): base(options) 
        { 
                
        }
        public DbSet<Products> products { get; set; }
        public DbSet<Categories> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
