using AtivSem03;
using DB.Application;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            var productApp = new ProductApp();
            var productList = productApp.ListAll();
            return View(productList);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var productApp = new ProductApp();
                productApp.Save(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult Update(int id)
        {
            var productApp = new ProductApp();
            var product = productApp.ListId(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                var productApp = new ProductApp();
                productApp.Save(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        public ActionResult Details(int id)
        {
            var productApp = new ProductApp();
            var product = productApp.ListId(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        public ActionResult Delete(int id)
        {
            var productApp = new ProductApp();
            var product = productApp.ListId(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            var productApp = new ProductApp();
            productApp.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
