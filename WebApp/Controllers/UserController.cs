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


        public ActionResult Update(int id)
        {
            var UserApp = new UserApp();
            var user = UserApp.ListId(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            if (ModelState.IsValid)
            {
                var UserApp = new UserApp();
                UserApp.Save(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Details(int id)
        {
            var UserApp = new UserApp();
            var user = UserApp.ListId(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        public ActionResult Delete(int id)
        {
            var UserApp = new UserApp();
            var user = UserApp.ListId(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var UserApp = new UserApp();
            UserApp.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
