using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    public class Cart
    {

        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public void AddItem (Project proj, int qty)
        {

            //looks at the list and sees if the book id in the list matches the book id is passed in
            //builds a new CarLine. Goes into Lines object, and selects where the project that was passed in is equal to the project in the Lines
            CartLine line = Lines
                .Where(p => p.Project.BookId == proj.BookId)
                .FirstOrDefault();

            //checks to see if it didn't find anything in the list that matches, and if it didn't it adds a new CartLine
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Project = proj,
                    Quantity = qty

                });
            }

            else
            {
                //go into carline, and set the quantity equal to whatever it is plus what was passed in (like adding another item if the item is already in the cart)
                line.Quantity += qty;
            }
        }

        //goes to lines and removes all that match
        public void RemoveLine(Project proj) =>
            Lines.RemoveAll(x => x.Project.BookId == proj.BookId); //returns a true or a false based on where the bookId matches the bookId passed in

        public void Clear() => Lines.Clear();

        public decimal ComputeTotalSum() =>
            (decimal)Lines.Sum(e => e.Project.Price * e.Quantity); //returns this line
        


        public class CartLine
        {
            public int CartLineID { get; set; }

            public Project Project { get; set; }

            public int Quantity { get; set; }
        }
    }
}
