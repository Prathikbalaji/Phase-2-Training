using ADOmvc.Data_Access;
using ADOmvc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ADOmvc.Controllers
{
    public class ProductsNewController : Controller
    {
        ProductDataAccess pd = new ProductDataAccess();
        // GET: ProductsNewController
        public IActionResult Index()
        {
            List<Products> lst = pd.select();
            return View(lst);
        }

        // GET: ProductsNewController/Details/5
        public ActionResult Details(int id)
        {
            Products lst = pd.search(id);
            return View(lst);
        }

        // GET: ProductsNewController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsNewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Products pdd)
        {
            try
            {
                pd.insert(pdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsNewController/Edit/5
        public ActionResult Edit(int id)
        {
            Products lst = pd.search(id);
            return View(lst);
        }

        // POST: ProductsNewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Products pdd)
        {
            try
            {
                pd.update(pdd);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsNewController/Delete/5
        public ActionResult Delete(int id)
        {
            Products lst = pd.search(id);
            return View(lst);
        }

        // POST: ProductsNewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Products pdd)
        {
            try
            {
                pd.delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
