using Microsoft.AspNetCore.Mvc;
using CoffeeShopRegistration.Models;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoffeeShopRegistration.Controllers
{
    public class UserController : Controller
    {

        static List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "Jessica",
                LastName = "Gates",
                Email = "jesstest@email.com",
                Password = "test1234"
            },
            new User
            {
                Id = 2,
                FirstName = "Patrick",
                LastName = "Gates",
                Email = "pattest@email.com",
                Password = "test1234"
            }
        };


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            IEnumerable<Category> categories = GetCategories();
            ViewBag.Categories = new SelectList(GetCategories(),"Id","Name"); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                model.Id = users.Max(x => x.Id) + 1;
                users.Add(model);
                ViewBag.ResultMessage = $"{model.FirstName} was successfully registered.";
                return RedirectToAction("Summary", model);
            }
            ViewBag.Categories = new SelectList(GetCategories(), "Id", "Name");
            ViewBag.ResultMessage = "There was a problem saving. Check the error messages and try again."; 
            return View(model); 
        }

        public IActionResult Summary(User model)
        {
            IEnumerable<Category> categories = GetCategories();
            Category category = categories.FirstOrDefault(x => x.Id == model.CategoryId);
            ViewBag.CategoryText = category == null ? "" : category.Name;
            return View(model);
        }

        private IEnumerable<Category> GetCategories()
        {
            List<Category> categories = new List<Category> {
            new Category { Id = 1, Name = "Friend/Family/Coworker"},
            new Category { Id = 2, Name = "Employee" },
            new Category { Id = 3, Name = "Google" },
            new Category { Id = 4, Name = "Advertisement" }
            };

            return categories;
        }
    }
}
