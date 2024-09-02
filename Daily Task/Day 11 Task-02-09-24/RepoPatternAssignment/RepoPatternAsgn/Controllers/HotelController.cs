using Microsoft.AspNetCore.Mvc;
using RepoPatternAsgn.Models;
using RepoPatternAsgn.Repository;

namespace RepoPatternAsgn.Controllers
{
    public class HotelController : Controller
    {

        private readonly IHotel htl;

        public HotelController(IHotel htl)
        {
            this.htl = htl;
        }

        public IActionResult Index()
        {
            return View(htl.getAll());
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(Hotel ht)
        {
            htl.AddHotel(ht);
            return RedirectToAction("Index");
        }

    }
}
