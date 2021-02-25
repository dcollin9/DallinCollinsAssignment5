using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models.ViewModels
{
    public class ProjectListViewModel
    {
        //can build multiple things in here

        //contains information that is the projects themselves, but will also have information about the paging
        public IEnumerable<Project> Projects { get; set; }
        public PagingInfo PagingInfo { get; set; }


    }
}
