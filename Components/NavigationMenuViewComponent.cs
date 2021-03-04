using DallinCollinsAssignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DallinCollinsAssignment5.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {

        private Assign5Repository repository;

        public string Invoke()
        {
            return "This worked";
        }
    }
}
