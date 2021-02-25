using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    public class Project
    {

        //declaring the different fields of the model
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string AuthorFirstName { get; set; }

        //the middle name isn't required because some authors have no middle name
        public string AuthorMiddleName { get; set; }

        [Required]
        public string AuthorLastName { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        [RegularExpression("^[0-9]{3}-[0-9]{10}$")] //ensures data is in the same ISBN format as is the original data
        public string ISBN { get; set; }

        [Required]
        public string Classification { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Price { get; set; }

        [Required]
        public int PageCount { get; set; }
    }
}
