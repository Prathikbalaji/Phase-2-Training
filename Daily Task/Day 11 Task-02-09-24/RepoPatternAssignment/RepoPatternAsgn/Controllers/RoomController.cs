using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RepoPatternAsgn.Models;
using RepoPatternAsgn.Repository;

namespace RepoPatternAsgn.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoom rm;
        private readonly IHotel htl;

        public RoomController(IRoom rm,IHotel htl) 
        {
            this.rm = rm;
            this.htl = htl;
        }

        public IActionResult Index()
        {
            return View(rm.getAllRooms());
        }

        public IActionResult Create()
        {
            ViewBag.Hotels = new SelectList(htl.getAll(),"HotelId","HotelName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Room rms)
        {
            rm.AddRoom(rms);
            return View();
        }

    }
}
