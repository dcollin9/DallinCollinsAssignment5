using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsAssignment5.Models
{
    public static class SeedData
    {

        public static void EnsurePopulated (IApplicationBuilder application)
        {
            Assignment5DBContext context = application.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<Assignment5DBContext>();

            //checks to see if there are any pending migrations
            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            //if there is nothing in the database already, add something
            if(!context.Projects.Any())
            {
                context.Projects.AddRange(

                    //adds information for different books
                    new Project
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorMiddleName = null,
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = "$9.95"
                    },

                    new Project
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleName = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = "$14.58"
                    },

                    new Project
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorMiddleName = null,
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = "$21.54"
                    },

                    new Project
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleName = "C.",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = "$11.61"
                    },

                    new Project
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorMiddleName = null,
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = "$13.33"
                    },

                    new Project
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorMiddleName = null,
                        AuthorLastName = "Chrichton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = "$15.95"
                    },

                    new Project
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorMiddleName = null,
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = "$14.99"
                    },

                    new Project
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorMiddleName = null,
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = "$21.66"
                    },
                    new Project
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorMiddleName = null,
                        AuthorLastName = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = "$29.16"
                    },
                    new Project
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorMiddleName = null,
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = "$15.03"
                    }



                );

                context.SaveChanges();
            }
        }
    }
}
