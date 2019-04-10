using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public partial class Category
    {
        public Category()
        {
            Post = new HashSet<Post>();
        }

        [Required(ErrorMessage = "Obligatoriskt att välja kategori!")]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Post> Post { get; set; }
    }
}
