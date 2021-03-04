using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models.ViewModels
{

    //sets info for the paging information
    public class PagingInfo
    {
        public int TotalNumItems { get; set; }

        public int ItemsPerPage { get; set; }

        public int CurrentPage { get; set; }

        //math.ceiling takes us up to the next whole number
        //we include the (decimal) because it converts TotalNumItems to a decimal so that the equation won't throw an error if the division produces a decimal
        //the (int) forces it to convert to an integer
        public int TotalPages => (int)(Math.Ceiling((decimal)TotalNumItems / ItemsPerPage));
    }
}
