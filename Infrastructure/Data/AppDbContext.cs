//using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        //public DbSet<Users> Users { get; set; }
        //public DbSet<Tasks> Tasks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
