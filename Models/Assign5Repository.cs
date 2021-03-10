using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    
    public interface Assign5Repository
    {

        //creates an iqueryable of type Project, which is what tells it the format of the model
        IQueryable<Project> Projects { get; }
    }
}
