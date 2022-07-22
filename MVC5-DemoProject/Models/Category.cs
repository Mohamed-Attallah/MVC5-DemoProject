using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC5_DemoProject.Models
{
    [Table("BookCategory")]
    public class Category
    {
        public int Id { get; set; }
        [Required,MaxLength(100)]

        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<Book> Books { get; set; }

    }
}