using Microsoft.EntityFrameworkCore;
using RepoPatternAsgn.Models;
using RepoPatternAsgn.Repository;

namespace RepoPatternAsgn.Service
{
    public class RoomService : IRoom
    {
        private readonly HotelDbContext _context;

        public RoomService(HotelDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Room> getAllRooms()
        {
            return _context.Rooms.Include(a => a.hotel).ToList();
        }

        public Room AddRoom(Room rm)
        {
            _context.Rooms.Add(rm);
            _context.SaveChanges();
            return rm;
        }

    }
}
