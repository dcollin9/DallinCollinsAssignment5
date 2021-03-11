using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DallinCollinsAssignment5.Infrastructure;
using DallinCollinsAssignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DallinCollinsAssignment5.Pages
{
    public class PurchaseModel : PageModel
    {
        private Assign5Repository repository;

        //constructor
        public PurchaseModel (Assign5Repository repo, Cart cartService)
        {
            //the repository is equal to the repo that is passed in
            repository = repo;
            Cart = cartService;
        }

        //properties
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //methods
        public void OnGet(string returnUrl)
        {
            //if it's null, return the slash
            ReturnUrl = returnUrl ?? "/";
        }

        //user is submitting something
        public IActionResult OnPost(long bookId, string returnUrl)
        {
            //looks at the repository, and the first thing that comes up when bookid = bookid
            Project project = repository.Projects.FirstOrDefault(p => p.BookId == bookId);


            //add an item to that cart, then add one
            Cart.AddItem(project, 1);

            //update the cart

            return RedirectToPage(new { returnUrl = returnUrl });
        }


        //locates the item in the cart and then removes it
        public IActionResult OnPostRemove(long bookId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl =>
                cl.Project.BookId == bookId).Project);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
