using DB.Application;
using DB.Domain;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var userApp = new UserApp();
            var userList = userApp.ListAll();
            return View(userList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
            var UserApp = new UserApp();
            UserApp.Save(user);
            return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}
