using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DallinCollinsAssignment5.Models;
using Microsoft.AspNetCore.Mvc;

namespace DallinCollinsAssignment5.Views.Shared.Components
{

    //receives a Cart object as a constructor argument, and passses on the Cart to the view method to help generate the necessary html
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }
        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
