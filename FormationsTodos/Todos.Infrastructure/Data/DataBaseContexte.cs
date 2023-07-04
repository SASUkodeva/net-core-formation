using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todos.Core.Entities;

namespace Todos.Infrastructure.Data
{
    internal class DataBaseContexte :DbContext
    {
    //  Add-Migration Initial -Context DataBaseContexte -Project Todos.Infrastructure -StartupProject Todos.WebApi -Verbose

        public DataBaseContexte()
        {
                
        }
        public DataBaseContexte(DbContextOptions<DataBaseContexte> options):base(options)
        {
                
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>().Property(s => s.TagCategories)
            .HasConversion(
                v => string.Join(',', v.Select(e => e.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                       .Select(s => s)
                    .ToArray());

        }
        public DbSet<Todo> Todos { get; set; }
    }
}
