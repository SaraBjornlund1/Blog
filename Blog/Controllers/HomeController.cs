using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Blog.Models;
using Blog.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.SqlServer;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Controllers
{
    public class HomeController : Controller
    {
        //Instans
        private BloggContext _context;

        //Anropar databasen
        public HomeController(BloggContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            BlogViewModel model = new BlogViewModel();

            foreach (var item in _context.Categories)
            {
                model.CategoryList.Add(new SelectListItem { Text = item.CategoryName, Value = item.CategoryId.ToString() });
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SavePost(Post post)
        {
            BlogViewModel model = new BlogViewModel();

            if (ModelState.IsValid)
            {
                _context.Posts.Add(post);

                _context.SaveChanges();

                ModelState.Clear();

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Search()
        {
            BlogViewModel model = new BlogViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(BlogViewModel values)
        {
            BlogViewModel model = new BlogViewModel();

            //Hämta alla headlines och kategorier i databasen som motsvarar sökningen
            model.Search = _context.Post.Where(p => p.HeadLine.Contains(values.SearchValue) || 
            p.Category.CategoryName.Contains(values.SearchValue)).ToList();

            //Tömmer sökrutan
            ModelState.Clear();

            return View(model);
        }

        public IActionResult ViewBlogPost()
        {
            List<Post> model = _context.Post.OrderByDescending(d => d.Date).ToList();

            return View(model);
        }

        public IActionResult SinglePost(int id)
        {
            var model = _context.Post.SingleOrDefault(p => p.PostId == id);
            
            return View(model);
        }

    }
}
