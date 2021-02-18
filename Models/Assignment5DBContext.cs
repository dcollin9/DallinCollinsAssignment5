using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    public class Assignment5DBContext : DbContext
    {
        public Assignment5DBContext  (DbContextOptions<Assignment5DBContext> options) : base (options)
        {

        }

        public DbSet<Project> Projects { get; set; }
    }
}
