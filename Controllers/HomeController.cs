using DallinCollinsAssignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DallinCollinsAssignment5.Models.ViewModels;

namespace DallinCollinsAssignment5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Assign5Repository _repository;

        //number of items per page
        public int PageSize = 5;



        public HomeController(ILogger<HomeController> logger, Assign5Repository repository)
        {
            _logger = logger;

            //creates private repository
            _repository = repository;
        }

        //if nothing else has been passed into the page variable, pass a 1 as the default
        public IActionResult Index(string category, int page = 1) 
        {

            return View(new ProjectListViewModel
            {
                //this is what will be returned to the view

                //go into Projects, and set it equal to the _repository Projects
                Projects = _repository.Projects
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.BookId)
                .Skip((page - 1) * PageSize) //supposing a 2 was passed in,  it skips out to element 5 of the array
                .Take(PageSize) //takes the items per page (5) starting at what it was skipped to
               ,
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,

                    //grabs number of items from the project at runtime (or the number of books in a category)
                    TotalNumItems = category == null ?_repository.Projects.Count() :
                        _repository.Projects.Where(x => x.Category == category).Count()
                },

                CurrentCategory = category
        });
                


               
                
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
