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
        

        //constructor to assign value of private variable
        public NavigationMenuViewComponent (Assign5Repository r)
        {
            repository = r;
        }

        public IViewComponentResult Invoke()
        {

            //grabs the value of the current page to pass to the Default.cshtml
            ViewBag.SelectedCategory = RouteData?.Values["category"];


            //returns a list of categories with no repeats
            return View(repository.Projects
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x)
                );

        }
    }
}
