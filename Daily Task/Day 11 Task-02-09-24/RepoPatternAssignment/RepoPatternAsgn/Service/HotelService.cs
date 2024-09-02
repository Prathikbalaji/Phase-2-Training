using Microsoft.EntityFrameworkCore;
using RepoPatternAsgn.Models;
using RepoPatternAsgn.Repository;

namespace RepoPatternAsgn.Service
{
    public class HotelService : IHotel
    {

        private readonly HotelDbContext _context;

        public HotelService(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Hotel> getAll()
        {
            return _context.Hotels.Include(o=>o.Rooms).ToList();
        }

        public Hotel AddHotel(Hotel hotel)
        {
            _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return hotel;
        }
    }
}
