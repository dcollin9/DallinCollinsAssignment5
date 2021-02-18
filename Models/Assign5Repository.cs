using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    public interface Assign5Repository
    {
        IQueryable<Project> Projects { get; }
    }
}
