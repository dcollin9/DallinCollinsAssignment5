using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{

    //inherits from the DbContext class
    public class Assignment5DBContext : DbContext
    {

        //inherits from base options
        public Assignment5DBContext  (DbContextOptions<Assignment5DBContext> options) : base (options)
        {

        }

        //sets Projects
        public DbSet<Project> Projects { get; set; }
    }
}
