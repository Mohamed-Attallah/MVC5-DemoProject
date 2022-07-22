using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC5_DemoProject.Models
{
    public class BooksDbContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public BooksDbContext():base("BooksConnectionString")
        {

         }
        
    }
}