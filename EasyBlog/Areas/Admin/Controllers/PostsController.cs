using EasyBlog.Areas.Admin.Models;
using EasyBlog.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EasyBlog.Areas.Admin.Controllers
{
    public class PostsController : AdminBaseController
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PostsController(ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            var posts = _db.Posts
                .Include(x => x.Category)
                .OrderByDescending(x => x.Id).ToList();
            return View(posts);
        }
        public IActionResult Create()
        {
            LoadSelectCategories();
            return View();
        }
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreatePostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                //todo: upload, image save post
                return RedirectToAction("Index");
            }
            LoadSelectCategories();
            return View();
        }
        private void LoadSelectCategories()
        {
            ViewBag.Categories = _db.Categories
               .OrderBy(x => x.Name)
               .Select(x => new SelectListItem()
               {
                   Text = x.Name,
                   Value = x.Id.ToString()
               })
               .ToList();
        }


    }
}
