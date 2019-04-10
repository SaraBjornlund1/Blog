using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Blog.ViewModels
{
    public class BlogViewModel
    {
        public Post post { get; set; }
        public Category category { get; set; }
        public string SearchValue { get; set; }
        

        //Listor
        public List<SelectListItem> CategoryList { get; set; } 
        public List<Post> Search { get; set; }
        public List<BlogViewModel> SearchAll { get; set; }

        public BlogViewModel()
        {
            CategoryList = new List<SelectListItem>();
            Search = new List<Post>();
            SearchAll = new List<BlogViewModel>();
            
        }
    }
}
