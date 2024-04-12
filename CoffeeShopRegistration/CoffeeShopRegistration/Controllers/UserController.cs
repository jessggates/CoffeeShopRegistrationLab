using Microsoft.AspNetCore.Mvc;
using CoffeeShopRegistration.Models;

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
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            if (ModelState.IsValid)
            {
                model.Id = users.Max(x => x.Id) + 1;
                users.Add(model);
                return RedirectToAction("Summary", model);
            }
            return View(model); 
        }

        public IActionResult Summary(User model)
        {
            return View(model);
        }
    }
}
